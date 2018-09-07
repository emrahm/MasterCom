using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Operation
{
    public class UpdateIssuerChargeback : IOperation
    {
        readonly ITransactionRepository _iTransactionData = null;
        readonly IChargebacks _iChargebacks;

        public UpdateIssuerChargeback(ITransactionRepository iTransactionData,
                                      IChargebacks iChargebacks)
        {
            _iTransactionData = iTransactionData;
            _iChargebacks = iChargebacks;
        }

        public void Create(MscMcomPool mscMcomPool)
        {
            var mscTransactionData = _iTransactionData.GetIssuerData(mscMcomPool);
            //reversalı yapılan chargeback işleminin chargeback id si pool dan bulunur
            MscMcomPool cbMscMcomPool = _iTransactionData.GetMscMcomPoolClearingNo(mscTransactionData.ClrNo, ApiConstants.PoolActionType.Chargeback);
            //claim transaction bilgisi ile bulunur
            MscMcomClaim mscMcomClaim = _iTransactionData.GetClaim(mscTransactionData.ProvGuid);
            //reversal request oluşturulur
            ChargebackRequest chargebackRequest = new ChargebackRequest();
            chargebackRequest.claimId = mscMcomClaim.ClaimId;
            chargebackRequest.chargebackId = cbMscMcomPool.McomRefNo;

            //update datası hazırlanır.
            ClrDocumentInfo clrDocumentInfo = _iTransactionData.GetDocumentInfo(mscTransactionData.Guid, ApiConstants.PoolActionType.ChargebackDocument);
            if (clrDocumentInfo == null)
                throw new Exception("Document not found for update");

            ChargebackFillRequest chargebackFillRequest = new ChargebackFillRequest();
            chargebackFillRequest.fileAttachment = _iTransactionData.GetAttachment(clrDocumentInfo);
            //memo bilgisi elde edilir. 
            chargebackFillRequest.memo = clrDocumentInfo.Description;

            //Chargeback reversal servisi cagrılır. 
            mscMcomPool.ResponseStatus = "";
            mscMcomPool.ClaimId = mscMcomClaim.ClaimId;
            mscMcomPool.McomRefNo = _iChargebacks.Update(mscMcomPool.ClearingRefKey, chargebackRequest, chargebackFillRequest);
        }
    }
}
