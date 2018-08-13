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

namespace Clearing.Msc.Business.MasterCom.Operation
{
    public class CreateChargeback
    {
        readonly ITransactionData _iTransactionData = null;
        readonly IChargebacks _iChargebacks = null;
        readonly IClaims _iClaims = null;
        readonly ITransactions _iTransactions = null;

        public CreateChargeback(ITransactionData iTransactionData,
                                ITransactions iTransactions,
                                IClaims iClaims,
                                IChargebacks iChargebacks)
        {
            _iTransactionData = iTransactionData;
            _iTransactions = iTransactions;
            _iClaims = iClaims;
            _iChargebacks = iChargebacks;
        }
 

        public void Create(MscMcomPool mscMcomPool)
        {
            //yapılan chargeback datası alınmakta.
            ChargebackFillRequest chargebackFillRequest = _iTransactionData.GetChargebackData(mscMcomPool.ClearingRefKey);

            //Chargeback yapılacak transaction mastrercom tarafından bulunur. Clearingtransaction id alınır.
            MscMcomTransactionId mscMcomTransactionId = GetMscMcomTransactionId(mscMcomPool,
                                                                                _iTransactions,
                                                                                _iTransactionData);
            
        }

        private MscMcomTransactionId GetMscMcomTransactionId(MscMcomPool mscMcomPool,
                                                             ITransactions iTransactions,
                                                             ITransactionData iTransactionData)
        {
            MscMcomTransactionId mscMcomTransactionId = iTransactionData.GetTransactionId(mscMcomPool.ProvisionRefKey);
            if (mscMcomTransactionId == null)
            {
                //presenment kaydı alınır
                var presentmentData = iTransactionData.GetPresentmentData(mscMcomPool);
                //transaction search yapılarak transaction id bulunur.
                TransactionSearchRequest transactionSearchRequest = new TransactionSearchRequest();
                transactionSearchRequest.primaryAccountNum = presentmentData.CardNo;
                transactionSearchRequest.acquirerRefNumber = presentmentData.Arn;
                transactionSearchRequest.tranStartDate = presentmentData.TxnDate.AddDays(-2).ToString("yyyy-MM-dd");
                transactionSearchRequest.tranEndDate = presentmentData.TxnDate.ToString("yyyy-MM-dd");
                var transactionSearchResponse = iTransactions.Search(transactionSearchRequest);
                if (Convert.ToInt16(transactionSearchResponse.authorizationSummaryCount) > 0)
                {
                    mscMcomTransactionId = new MscMcomTransactionId();
                    mscMcomTransactionId.ClearingTransactionId = transactionSearchResponse.authorizationSummary[0].clearingSummary[0].transactionId;
                    mscMcomTransactionId.AuthenticationTransactionId = transactionSearchResponse.authorizationSummary[0].transactionId;
                    mscMcomTransactionId.ClrRefKey = mscMcomPool.ClearingRefKey;
                    mscMcomTransactionId.AuthRefNo = mscMcomPool.ProvisionRefKey;
                    iTransactionData.CreateTransactionId(mscMcomTransactionId);
                }
            }
            return mscMcomTransactionId;
        } 
    }
}
