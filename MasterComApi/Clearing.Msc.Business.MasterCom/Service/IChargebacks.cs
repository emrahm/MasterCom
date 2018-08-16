using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Model
{
    public interface IChargebacks
    {
        List<ChargebackResponse> AcknowledgeReceivedChargebacks(long refKey, List<ChargebackRequest> chargebackRequestList);
        List<ChargebackStatusResponse> ChargebacksStatus(long refKey, List<ChargebackRequest> chargebackRequestList);
        string Create(long refKey, string claimId, ChargebackFillRequest chargebackRequest);
        string CreateReversal(long refKey, ChargebackRequest chargebackRequest);
        FileAttachment RetrieveDocumentation(long refKey, ChargebackRequest chargebackRequest);
        string Update(long refKey, ChargebackRequest chargebackRequest, ChargebackFillRequest chargebackFillRequest);
    }
}
