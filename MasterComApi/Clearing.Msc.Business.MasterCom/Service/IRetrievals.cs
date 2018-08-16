using Clearing.Msc.Business.MasterCom.ModelData;
using System;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface IRetrievals
    {
        string AcquirerFulfillRequest(long refKey, string claimId, string requestId, RetrievalFulfillmentRequest retrievalFulfillmentRequest);
        string CreateRetrieval(long refKey, string claimId, RetrievalCreateRequest retrievalCreateRequest);
        FileAttachment GetDocumentation(long refKey, string claimId, string requestId);
        string IssuerRespondToFulfillment(long refKey, string claimId, string requestId, RetrievalResponseFulfillmentRequest retrievalResponseFulfillmentRequest);
    }
}
