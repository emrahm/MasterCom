using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Model
{
    /*
        "/mastercom/v1/claims/{claim-id}/retrievalrequests/{request-id}/fulfillments", "create"
        "/mastercom/v1/claims/{claim-id}/retrievalrequests", "create"
        "/mastercom/v1/claims/{claim-id}/retrievalrequests/loaddataforretrievalrequests", "query"
        "/mastercom/v1/claims/{claim-id}/retrievalrequests/{request-id}/documents", "query";
        "/mastercom/v1/claims/{claim-id}/retrievalrequests/{request-id}/fulfillments/response", "create"
        "/mastercom/v1/retrievalrequests/status", "update" 
     */
    public class Retrievals : IRetrievals
    {
        IApiController _apiController = null;
        public Retrievals(IApiController apiController)
        {
            _apiController = apiController;
        }


        public string CreateRetrieval(long refKey, string claimId, RetrievalCreateRequest retrievalCreateRequest)
        {
            var result = _apiController.Create<RetrievalResponse>(refKey, String.Format("claims/{0}/retrievalrequests", claimId), retrievalCreateRequest);
            return result.requestId;
        }

        public string AcquirerFulfillRequest(long refKey, string claimId, string requestId, RetrievalFulfillmentRequest retrievalFulfillmentRequest)
        {
            var result = _apiController.Create<RetrievalResponse>(refKey, String.Format("claims/{0}/retrievalrequests/{1}/fulfillments", claimId, requestId),
                                                                  retrievalFulfillmentRequest);
            return result.requestId;
        }

        public string IssuerRespondToFulfillment(long refKey, string claimId, string requestId, RetrievalResponseFulfillmentRequest retrievalResponseFulfillmentRequest)
        {
            var result = _apiController.Create<RetrievalResponse>(refKey, String.Format("claims/{0}/retrievalrequests/{1}/fulfillments/response", claimId, requestId),
                                                             retrievalResponseFulfillmentRequest);
            return result.requestId;
        }

        public FileAttachment GetDocumentation(long refKey, string claimId, string requestId)
        {
            Dictionary<string, String> parameterQuery = new Dictionary<string,string>();
            return _apiController.Get<FileAttachment>(refKey, String.Format("claims/{0}/retrievalrequests/{1}/documents", claimId, requestId), parameterQuery);
        } 
    }
}
