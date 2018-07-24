// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.ApiController
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using log4net;
using log4net.Config;
using MasterCard.Core.Exceptions;
using MasterCard.Core.Model;
using MasterCard.Core.Security;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MasterCard.Core
{
    public class ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ApiController));
        private static readonly string EnvironmentIdentifier = "#env";
        private IRestClient restClient;

        static ApiController()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (!ApiConfig.IsDebug())
                return;
            //if (System.IO.File.Exists("log4net.xml"))
            //    XmlConfigurator.Configure(new FileInfo("log4net.xml"));
            //else
            BasicConfigurator.Configure();
        }

        public ApiController()
        {
            this.CheckState();
        }

        public void SetRestClient(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public virtual IDictionary<string, object> Execute(OperationConfig config, OperationMetadata metadata, BaseObject requestMap)
        {
            RestyRequest request;
            CryptographyInterceptor interceptor;
            IRestClient restClient;
            try
            {
                request = this.GetRequest(config, metadata, (RequestMap)requestMap);
                interceptor = request.interceptor;
                if (this.restClient != null)
                {
                    restClient = this.restClient;
                    restClient.BaseUrl = request.BaseUrl;
                }
                else
                    restClient = (IRestClient)new RestClient(request.BaseUrl);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, ex);
            }
            IRestResponse response;
            try
            {
                ApiController.log.Debug((object)(">>Execute(action='" + config.Action + "', resourcePaht='" + config.ResourcePath + "', requestMap='" + (object)requestMap + "'"));
                ApiController.log.Debug((object)("excute(), request.Method='" + (object)request.Method + "'"));
                ApiController.log.Debug((object)("excute(), request.URL=" + request.AbsoluteUrl.ToString()));
                ApiController.log.Debug((object)"excute(), request.Header=");
                ApiController.log.Debug((object)request.Parameters.Where<Parameter>((Func<Parameter, bool>)(x => x.Type == ParameterType.HttpHeader)));
                ApiController.log.Debug((object)"excute(), request.Body=");
                ApiController.log.Debug((object)request.Parameters.Where<Parameter>((Func<Parameter, bool>)(x => x.Type == ParameterType.RequestBody)));
                response = restClient.Execute((IRestRequest)request);
                ApiController.log.Debug((object)"Execute(), response.Header=");
                ApiController.log.Debug((object)response.Headers);
                ApiController.log.Debug((object)"Execute(), response.Body=");
                ApiController.log.Debug((object)response.Content.ToString());
            }
            catch (Exception ex)
            {
                Exception exception = (Exception)new ApiException(ex.Message, ex);
                ApiController.log.Error((object)exception.Message, exception);
                throw exception;
            }
            if (response.ErrorException == null && response.Content != null)
            {
                IDictionary<string, object> dictionary = (IDictionary<string, object>)new Dictionary<string, object>();
                if (response.Content.Length > 0)
                {
                    try
                    {
                        dictionary = SmartMap.AsDictionary(response.Content);
                        if (interceptor != null)
                            dictionary = interceptor.Encrypt(dictionary);
                    }
                    catch (Exception ex)
                    {
                        throw new ApiException("Error: parsing JSON response", response.Content);
                    }
                }
                if (response.StatusCode < HttpStatusCode.MultipleChoices)
                {
                    ApiController.log.Debug((object)"<<Execute()");
                    return dictionary;
                }
                ApiException exception = ApiController.GenerateException(dictionary, response);
                ApiController.log.Error((object)exception.Message, (Exception)exception);
                throw exception;
            }
            Exception exception1 = (Exception)new ApiException(response.ErrorMessage, response.ErrorException);
            ApiController.log.Error((object)exception1.Message, exception1);
            throw exception1;
        }

        private static ApiException GenerateException(IDictionary<string, object> responseObj, IRestResponse response)
        {
            int status = (int)response.StatusCode;
            if (responseObj != null)
                return new ApiException(status, responseObj);
            return new ApiException(status.ToString(), response.Content);
        }

        private void CheckState()
        {
            if (ApiConfig.GetAuthentication() == null)
                throw new InvalidOperationException("No ApiConfig.authentication has been configured");
        }

        private void AppendToQueryString(StringBuilder s, string stringToAppend)
        {
            if (s.ToString().IndexOf("?") == -1)
                s.Append("?");
            if (s.ToString().IndexOf("?") != s.Length - 1)
                s.Append("&");
            s.Append(stringToAppend);
        }

        private string GetURLEncodedString(object stringToEncode)
        {
            return HttpUtility.UrlEncode(stringToEncode.ToString(), Encoding.UTF8);
        }

        public Uri GetURL(OperationConfig config, OperationMetadata metadata, IDictionary<string, object> inputMap)
        {
            List<string> queryParams = config.QueryParams;
            string host = metadata.Host;
            if (host == null)
                throw new InvalidOperationException("Host is '', empty");
            string str1 = config.ResourcePath;
            if (str1.Contains(ApiController.EnvironmentIdentifier))
            {
                string newValue = "";
                if (metadata.Context != null)
                    newValue = metadata.Context;
                str1 = str1.Replace(ApiController.EnvironmentIdentifier, newValue).Replace("//", "/");
            }
            string str2 = str1;
            string replacedPath = Util.GetReplacedPath(host + str2, inputMap);
            int num1 = 0;
            List<object> objectList = new List<object>();
            string str3 = "{";
            int num2 = num1;
            int num3 = 1;
            int num4 = num2 + num3;
            // ISSUE: variable of a boxed type
            int local1 = num2;
            string str4 = "}";
            StringBuilder s1 = new StringBuilder(str3 + (object)local1 + str4);
            objectList.Add((object)replacedPath);
            string action1 = config.Action;
            if ((action1 == "read" || action1 == "delete" || (action1 == "list" || action1 == "query")) && (inputMap != null && inputMap.Count > 0))
            {
                foreach (KeyValuePair<string, object> input in (IEnumerable<KeyValuePair<string, object>>)inputMap)
                {
                    this.AppendToQueryString(s1, "{" + (object)num4++ + "}={" + (object)num4++ + "}");
                    objectList.Add((object)this.GetURLEncodedString((object)input.Key.ToString()));
                    objectList.Add((object)this.GetURLEncodedString((object)input.Value.ToString()));
                }
            }
            if (queryParams.Count > 0)
            {
                string action2 = config.Action;
                if (action2 == "create" || action2 == "update")
                {
                    foreach (KeyValuePair<string, object> sub in (IEnumerable<KeyValuePair<string, object>>)Util.SubMap(inputMap, queryParams))
                    {
                        StringBuilder s2 = s1;
                        object[] objArray = new object[5];
                        objArray[0] = (object)"{";
                        int index1 = 1;
                        int num5 = num4;
                        int num6 = 1;
                        int num7 = num5 + num6;
                        // ISSUE: variable of a boxed type
                        object local2 = num5;
                        objArray[index1] = (object)local2;
                        int index2 = 2;
                        string str5 = "}={";
                        objArray[index2] = (object)str5;
                        int index3 = 3;
                        int num8 = num7;
                        int num9 = 1;
                        num4 = num8 + num9;
                        // ISSUE: variable of a boxed type
                        object local3 = num8;
                        objArray[index3] = (object)local3;
                        int index4 = 4;
                        string str6 = "}";
                        objArray[index4] = (object)str6;
                        string stringToAppend = string.Concat(objArray);
                        this.AppendToQueryString(s2, stringToAppend);
                        objectList.Add((object)this.GetURLEncodedString((object)sub.Key.ToString()));
                        objectList.Add((object)this.GetURLEncodedString((object)sub.Value.ToString()));
                    }
                }
            }
            this.AppendToQueryString(s1, "Format=JSON");
            try
            {
                return new Uri(string.Format(s1.ToString(), objectList.ToArray()));
            }
            catch (UriFormatException ex)
            {
                throw new InvalidOperationException("Failed to build URI", (Exception)ex);
            }
        }

        private RestyRequest GetRequest(OperationConfig config, OperationMetadata metadata, RequestMap requestMap)
        {
            RestyRequest restyRequest = (RestyRequest)null;
            IDictionary<string, object> dictionary1 = (IDictionary<string, object>)requestMap.Clone();
            IDictionary<string, object> dictionary2 = Util.SubMap(dictionary1, config.HeaderParams);
            Uri url = this.GetURL(config, metadata, dictionary1);
            Uri uri = new Uri(url.Scheme + "://" + url.Host + ":" + (object)url.Port);
            CryptographyInterceptor cryptographyInterceptor = ApiConfig.GetCryptographyInterceptor(url.AbsolutePath);
            string action = config.Action;
            if (!(action == "create"))
            {
                if (!(action == "delete"))
                {
                    if (!(action == "update"))
                    {
                        if (action == "read" || action == "list" || action == "query")
                            restyRequest = new RestyRequest(url, Method.GET);
                    }
                    else
                    {
                        restyRequest = new RestyRequest(url, Method.PUT);
                        if (cryptographyInterceptor != null)
                            dictionary1 = cryptographyInterceptor.Encrypt(dictionary1);
                        restyRequest.AddJsonBody((object)dictionary1);
                    }
                }
                else
                    restyRequest = new RestyRequest(url, Method.DELETE);
            }
            else
            {
                restyRequest = new RestyRequest(url, Method.POST);
                if (cryptographyInterceptor != null)
                    dictionary1 = cryptographyInterceptor.Encrypt(dictionary1);
                restyRequest.AddJsonBody((object)dictionary1);
            }
            restyRequest.AddHeader("Accept", "application/json");
            restyRequest.AddHeader("Content-Type", "application/json");
            restyRequest.AddHeader("User-Agent", "CSharp-SDK/" + metadata.Version);
            foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>)dictionary2)
                restyRequest.AddHeader(keyValuePair.Key, keyValuePair.Value.ToString());
            ApiConfig.GetAuthentication().SignRequest(url, (IRestRequest)restyRequest);
            restyRequest.AbsoluteUrl = url;
            restyRequest.BaseUrl = uri;
            restyRequest.interceptor = cryptographyInterceptor;
            return restyRequest;
        }
    }
}
