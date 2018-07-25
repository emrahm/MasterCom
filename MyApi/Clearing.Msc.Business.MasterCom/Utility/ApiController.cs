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
            Uri url = GetUrl(restUrl, parameterQuery);
            IRestRequest restyRequest = GetRestRequest(url, Method.GET);
            _authAuthentication.SignRequest(url, restyRequest);
            _restClient.BaseUrl = GetBaseUrl(url);
            IRestResponse response = _restClient.Execute(restyRequest);
            return GetResponse<T>(response);
        }



        public T Create<T>(String restUrl, object fromBody)
        {
            Uri url = GetUrl(restUrl, null);
            IRestRequest restyRequest = GetRestRequest(url, Method.POST);
            restyRequest.AddJsonBody(fromBody);
            _authAuthentication.SignRequest(url, restyRequest);
            _restClient.BaseUrl = GetBaseUrl(url);
            IRestResponse response = _restClient.Execute(restyRequest);
            return GetResponse<T>(response);
        }


        private IRestRequest GetRestRequest(Uri url, Method method)
        {
            IRestRequest restyRequest = new RestRequest(url, method);
            restyRequest.AddHeader("Accept", "application/json");
            restyRequest.AddHeader("Content-Type", "application/json");
            restyRequest.AddHeader("User-Agent", "CSharp-SDK/" + _mcomConfig.UserAgentVersion);
            return restyRequest;
        }

        private T GetResponse<T>(IRestResponse response)
        {
            HttpStatusCode statusCode = response.StatusCode;
            if (statusCode == HttpStatusCode.OK)
            {
                return deserial.Deserialize<T>(response);
            }
            else
                throw ThrowBadRequest(response);
        }

        private Exception ThrowBadRequest(IRestResponse response)
        {
            ResponseErrorContent x = null;
            try
            {
                x = deserial.Deserialize<ResponseErrorContent>(response);
            }
            catch (Exception)
            {
                return new Exception(response.Content);
            }

            StringBuilder errorMessages = new StringBuilder();
            foreach (var item in x.Errors.Error)
            {
                errorMessages.AppendLine(item.Description);
            }
            return new Exception(errorMessages.ToString());
        }

        private Uri GetUrl(string restUrl, Dictionary<string, string> parameterQuery)
        {
            return Util.GetUrl(_mcomConfig.BaseUrl,
                               _mcomConfig.UrlVersionNumber,
                               restUrl,
                               parameterQuery);
        }

        private Uri GetBaseUrl(Uri uri)
        {
            return new Uri(uri.Scheme + "://" + uri.Host + ":" + (object)uri.Port);
        }
    }
}
