using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface IChargebacks
    {
        List<ChargebackResponse> AcknowledgeReceivedChargebacks(List<ChargebackRequest> chargebackRequestList);
        List<ChargebackStatusResponse> ChargebacksStatus(List<ChargebackRequest> chargebackRequestList);
        string Create(string claimId, ChargebackFillRequest chargebackRequest);
        string CreateReversal(ChargebackRequest chargebackRequest);
        FileAttachment RetrieveDocumentation(ChargebackRequest chargebackRequest);
        string Update(ChargebackRequest chargebackRequest, ChargebackFillRequest chargebackFillRequest);
    }
}
