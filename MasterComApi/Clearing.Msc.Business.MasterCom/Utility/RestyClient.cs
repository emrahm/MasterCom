using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Repository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Utility
{
    /// <summary>
    /// This class takes log of the request and response of rest api calls.
    /// </summary>
    public class RestyClient : IRestyClient
    {
        IRestClient restClient = null;
        IMscMcomRequestRepository _mscMcomRequestRepository = null;
        public RestyClient(IMscMcomRequestRepository mscMcomRequestRepository,
                           IRestClient iRestClient)
        {
            _mscMcomRequestRepository = mscMcomRequestRepository;
            restClient = iRestClient;
        }

        public IRestResponse Execute(long refKey, Uri url, IRestRequest restRequest)
        {
            restClient.BaseUrl = GetBaseUrl(url);
            MscMcomRequest mscMcomRequest = GetMscMcomRequest(url, refKey, restRequest);
            var restResponse = restClient.Execute(restRequest);
            UpdateRestResponse(mscMcomRequest, restResponse);
            _mscMcomRequestRepository.Create(mscMcomRequest);
            return restResponse;
        }

        private Uri GetBaseUrl(Uri uri)
        {
            return new Uri(uri.Scheme + "://" + uri.Host + ":" + (object)uri.Port);
        }

        private MscMcomRequest GetMscMcomRequest(Uri url, Int64 refKey, IRestRequest restRequest)
        {
            MscMcomRequest mscMcomRequest = new MscMcomRequest();
            mscMcomRequest.RefKey = refKey;
            mscMcomRequest.Url = url.PathAndQuery;
            mscMcomRequest.Request = GetBody(restRequest);
            return mscMcomRequest;
        }

        private void UpdateRestResponse(MscMcomRequest mscMcomRequest, IRestResponse restResponse)
        {
            mscMcomRequest.HttpStatus = 200;
            mscMcomRequest.Response = restResponse.Content;
        }

        private String GetBody(IRestRequest restRequest)
        {
            String body = String.Empty;
            foreach (var item in restRequest.Parameters)
            {
                if (item.Type == ParameterType.RequestBody)
                    body = item.Value.ToString();
            }
            return body;
        }
    }
}
