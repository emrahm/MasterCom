using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Operation
{
    /// <summary>
    /// chargeback create
    /// </summary>
    public class CreateIssuerChargeback : IOperation
    {
        readonly ITransactionRepository _iTransactionData = null;
        readonly IChargebacks _iChargebacks = null;
        readonly IClaims _iClaims = null;
        readonly ITransactions _iTransactions = null;

        public CreateIssuerChargeback(ITransactionRepository iTransactionData,
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
            ChargebackFillRequest chargebackFillRequest = GetChargebackData(mscMcomPool);
            //Chargeback yapılacak transaction mastrercom tarafından bulunur. Clearingtransaction id alınır.
            MscMcomTransaction mscMcomTransactionId = GetMscMcomTransactionId(mscMcomPool);
            //claim bulunur.
            MscMcomClaim mscMcomClaim = GetMscMcomClaim(mscMcomPool, chargebackFillRequest, mscMcomTransactionId);
            //chargeback üretilir. 
            mscMcomPool.ResponseStatus = "INITIAL";
            mscMcomPool.ClaimId = mscMcomClaim.ClaimId;
            mscMcomPool.McomRefNo = _iChargebacks.Create(mscMcomPool.ClearingRefKey, mscMcomClaim.ClaimId, chargebackFillRequest);
        }

        private ChargebackFillRequest GetChargebackData(MscMcomPool mscMcomPool)
        {
            var mscTransactionData = _iTransactionData.GetIssuerData(mscMcomPool); 
            ChargebackFillRequest chargebackFillRequest = new ChargebackFillRequest();
            chargebackFillRequest.documentIndicator = mscTransactionData.F072;
            chargebackFillRequest.messageText = mscTransactionData.F072;
            chargebackFillRequest.amount = mscTransactionData.F004.ToString(CultureInfo.GetCultureInfo("en-US"));
            chargebackFillRequest.currency = mscTransactionData.F049;
            chargebackFillRequest.reasonCode = mscTransactionData.F025;
            chargebackFillRequest.chargebackType = ApiConstants.ChargebackStatus.Chargeback;
            chargebackFillRequest.memo = mscTransactionData.F072;
            ClrDocumentInfo clrDocumentInfo = _iTransactionData.GetDocumentInfo(mscTransactionData.Guid, ApiConstants.PoolActionType.ChargebackDocument);
            if (clrDocumentInfo != null)
                chargebackFillRequest.fileAttachment = _iTransactionData.GetAttachment(clrDocumentInfo);
            return chargebackFillRequest;
        }

        /// <summary>
        ///  claim bulunur database de varsa o alınır yoksa yeni bir claim yaratılır.
        ///  transaction tanımında claim varsa alır yoksa mastercard sistemden claim numarası alır.
        ///  alınan claim transaction uzerine kaydeder.
        /// </summary>
        /// <param name="mscMcomPool"></param>
        /// <param name="chargebackFillRequest"></param>
        /// <param name="mscMcomTransactionId"></param>
        /// <returns></returns>
        private MscMcomClaim GetMscMcomClaim(MscMcomPool mscMcomPool, ChargebackFillRequest chargebackFillRequest, MscMcomTransaction mscMcomTransactionId)
        {
            MscMcomClaim mscMcomClaim = null;
            if (!String.IsNullOrWhiteSpace(mscMcomTransactionId.ClaimId))
                mscMcomClaim = _iTransactionData.GetClaim(mscMcomTransactionId.ClaimId);

            if (mscMcomClaim == null)
            {
                mscMcomClaim = new MscMcomClaim();

                var claimRequest = new ClaimRequest();
                claimRequest.clearingTransactionId = mscMcomTransactionId.ClearingTransactionId;
                claimRequest.disputedAmount = chargebackFillRequest.amount;
                claimRequest.disputedCurrency = chargebackFillRequest.currency;
                claimRequest.claimType = "Standard";
                mscMcomClaim.ClaimId = _iClaims.CreateClaim(mscMcomPool.ClearingRefKey, claimRequest);
                mscMcomClaim.ClearingTransactionId = mscMcomTransactionId.ClearingTransactionId;
                mscMcomClaim.ClrKey = mscMcomPool.ClearingRefKey;
                mscMcomClaim.AuthKey = mscMcomPool.ProvisionRefKey;
                mscMcomClaim.ClaimStatu = "OPEN";
                _iTransactionData.CreateClaim(mscMcomClaim);
                mscMcomTransactionId.ClaimId = mscMcomClaim.ClaimId;
                _iTransactionData.UpdateClaimId(mscMcomTransactionId);
            }

            return mscMcomClaim;
        }
        /// <summary>
        /// Transaction id bulunur
        /// </summary>
        /// <param name="mscMcomPool"></param>
        /// <returns></returns>
        private MscMcomTransaction GetMscMcomTransactionId(MscMcomPool mscMcomPool)
        {
            MscMcomTransaction mscMcomTransactionId = _iTransactionData.GetTransactionId(mscMcomPool.ProvisionRefKey);
            if (mscMcomTransactionId == null)
            {
                //presenment kaydı alınır
                var presentmentData = _iTransactionData.GetIssuerData(mscMcomPool);
                //transaction search yapılarak transaction id bulunur.
                TransactionSearchRequest transactionSearchRequest = new TransactionSearchRequest();
                transactionSearchRequest.primaryAccountNum = presentmentData.F002;
                transactionSearchRequest.acquirerRefNumber = presentmentData.Arn;
                transactionSearchRequest.tranStartDate = presentmentData.TxnDate.AddDays(-2).ToString("yyyy-MM-dd");
                transactionSearchRequest.tranEndDate = presentmentData.TxnDate.ToString("yyyy-MM-dd");
                var transactionSearchResponse = _iTransactions.Search(mscMcomPool.ClearingRefKey, transactionSearchRequest);
                if (Convert.ToInt16(transactionSearchResponse.authorizationSummaryCount) > 0)
                {
                    mscMcomTransactionId = new MscMcomTransaction();
                    mscMcomTransactionId.ClearingTransactionId = transactionSearchResponse.authorizationSummary[0].clearingSummary[0].transactionId;
                    mscMcomTransactionId.AuthenticationTransactionId = transactionSearchResponse.authorizationSummary[0].transactionId;
                    mscMcomTransactionId.ClrRefKey = mscMcomPool.ClearingRefKey;
                    mscMcomTransactionId.AuthRefKey = mscMcomPool.ProvisionRefKey;
                    _iTransactionData.CreateTransactionId(mscMcomTransactionId);
                }
            }
            return mscMcomTransactionId;
        }
    }
}
