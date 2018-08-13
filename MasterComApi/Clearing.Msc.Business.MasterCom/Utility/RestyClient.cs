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
    public class RestyClient 
    {
        RestClient restClient = null;
        IMscMcomRequestRepository _mscMcomRequestRepository = null;
        public RestyClient(IMscMcomRequestRepository mscMcomRequestRepository)
        {
            _mscMcomRequestRepository = mscMcomRequestRepository;
            restClient = new RestClient();
        }

        public IRestResponse Execute(Uri url, IRestRequest restRequest)
        {
            restClient.BaseUrl = GetBaseUrl(url);
            MscMcomRequest mscMcomRequest = GetMscMcomRequest(url, 0, restRequest);
            Int64 guid = _mscMcomRequestRepository.Create(mscMcomRequest);
            var restResponse = restClient.Execute(restRequest);
            UpdateRestResponse(mscMcomRequest, restResponse);
            _mscMcomRequestRepository.Update(guid,  mscMcomRequest);
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
            mscMcomRequest.Request =  "";
            return mscMcomRequest;
        }

        private void UpdateRestResponse(MscMcomRequest mscMcomRequest, IRestResponse restResponse)
        {
            mscMcomRequest.HttpStatus = 200;
        }
    }
}
