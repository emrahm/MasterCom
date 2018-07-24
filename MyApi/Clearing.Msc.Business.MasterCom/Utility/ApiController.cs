using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Security;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Utility
{
    public class ApiController : IApiController
    {
        JsonDeserializer deserial = new JsonDeserializer();
        private readonly IMcomConfig _mcomConfig;
        private readonly IAuthAuthentication _authAuthentication;
        private readonly IRestClient _restClient;

        public ApiController(IMcomConfig mcomConfig,
                             IAuthAuthentication authAuthentication,
                             IRestClient iRestClient)
        {
            _mcomConfig = mcomConfig;
            _authAuthentication = authAuthentication;
            _restClient = iRestClient;
        }

        public T Get<T>(String restUrl, Dictionary<String, String> parameterQuery)
        {
            if (parameterQuery == null)
                parameterQuery = new Dictionary<string, string>();
            Uri url = new Uri(GetUrl(restUrl, parameterQuery));
            Uri uri = new Uri(url.Scheme + "://" + url.Host + ":" + (object)url.Port);
            IRestRequest restyRequest = new RestRequest(url, Method.GET);
            restyRequest.AddHeader("Accept", "application/json");
            restyRequest.AddHeader("Content-Type", "application/json");
            restyRequest.AddHeader("User-Agent", "CSharp-SDK/" + _mcomConfig.UserAgentVersion);
            _authAuthentication.SignRequest(url, restyRequest);
            _restClient.BaseUrl = uri;
            IRestResponse response = _restClient.Execute(restyRequest);
            return GetResponse<T>(response);
        }

        private T GetResponse<T>(IRestResponse response)
        {
            HttpStatusCode statusCode = response.StatusCode;
            if (statusCode == HttpStatusCode.OK)
            {
                return deserial.Deserialize<T>(response);
            }
            else
            {
                ResponseErrorContent x = deserial.Deserialize<ResponseErrorContent>(response);
                StringBuilder errorMessages = new StringBuilder();
                foreach (var item in x.Errors.Error)
                {
                    errorMessages.AppendLine(item.Description);
                }
                throw new Exception(errorMessages.ToString());
            }
        }


        private String GetUrl(String restUrl, Dictionary<String, String> parameterQuery)
        {
            String url = _mcomConfig.BaseUrl + _mcomConfig.UrlVersionNumber + restUrl;
            parameterQuery.Add("Format", "JSON");
            String queryParameter = "";
            foreach (var item in parameterQuery)
            {
                queryParameter += String.Format("&{0}={1}", item.Key, item.Value);
            }
            url += queryParameter.Substring(1);
            return url;
        }



        public object Create<T1>(string p, Dictionary<string, string> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
