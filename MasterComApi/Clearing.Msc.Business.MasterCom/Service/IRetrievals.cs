using Clearing.Msc.Business.MasterCom.ModelData;
using System;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface IRetrievals
    {
        string AcquirerFulfillRequest(string claimId, string requestId, RetrievalFulfillmentRequest retrievalFulfillmentRequest);
        string CreateRetrieval(string claimId, RetrievalCreateRequest retrievalCreateRequest);
        FileAttachment GetDocumentation(string claimId, string requestId);
        string IssuerRespondToFulfillment(string claimId, string requestId, RetrievalResponseFulfillmentRequest retrievalResponseFulfillmentRequest);
    }
}
