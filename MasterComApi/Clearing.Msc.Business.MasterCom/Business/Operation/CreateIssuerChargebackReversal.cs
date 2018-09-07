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
    /// <summary>
    /// chargeback create
    /// </summary>
    public class CreateIssuerChargebackReversal : IOperation
    {
        readonly ITransactionRepository _iTransactionData = null;
        readonly IChargebacks _iChargebacks;

        public CreateIssuerChargebackReversal(ITransactionRepository iTransactionData,
                                              IChargebacks iChargebacks)
        {
            _iTransactionData = iTransactionData;
            _iChargebacks = iChargebacks;
        } 

        public void Create(MscMcomPool mscMcomPool)
        {
            //cb reversal datası alınır
            var cbReversalData = _iTransactionData.GetIssuerData(mscMcomPool);
            //reversalı yapılan chargeback işleminin chargeback id si pool dan bulunur
            MscMcomPool cbMscMcomPool = _iTransactionData.GetMscMcomPoolClearingNo(cbReversalData.PrevClearingNo, ApiConstants.PoolActionType.Chargeback); 
            //claim transaction bilgisi ile bulunur
            MscMcomClaim mscMcomClaim = _iTransactionData.GetClaim(cbReversalData.ProvGuid);
            //reversal request oluşturulur
            ChargebackRequest  chargebackRequest  = new ChargebackRequest();
            chargebackRequest.claimId = mscMcomClaim.ClaimId;
            chargebackRequest.chargebackId = cbMscMcomPool.McomRefNo;
            //Chargeback reversal servisi cagrılır.
            mscMcomPool.ResponseStatus = "INITIAL";
            mscMcomPool.ClaimId = mscMcomClaim.ClaimId;
            mscMcomPool.McomRefNo = _iChargebacks.CreateReversal(mscMcomPool.ClearingRefKey, chargebackRequest);
        } 
    }
}
