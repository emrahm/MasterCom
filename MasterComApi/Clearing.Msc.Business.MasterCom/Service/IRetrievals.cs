using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Model
{
    public interface IRetrievals
    {
        string AcquirerFulfillRequest(long refKey, string claimId, string requestId, RetrievalFulfillmentRequest retrievalFulfillmentRequest);
        string CreateRetrieval(long refKey, string claimId, RetrievalCreateRequest retrievalCreateRequest);
        FileAttachment GetDocumentation(long refKey, string claimId, string requestId);
        string IssuerRespondToFulfillment(long refKey, string claimId, string requestId, RetrievalResponseFulfillmentRequest retrievalResponseFulfillmentRequest);
        List<RetrievalResponse> RetrievalFullfilmentStatus(long refKey, List<RetrievalRequest> retrievalRequestList); 
    }
}
