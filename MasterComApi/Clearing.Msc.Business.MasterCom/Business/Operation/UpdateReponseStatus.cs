using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Utility;
using Smartway.Ocean.Framework.Pom;
using Smartway.Ocean.Framework.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Operation
{
    public class UpdateReponseStatus : IOperation
    {
        readonly ITransactionRepository _iTransactionData = null;
        readonly IChargebacks _iChargebacks;
        readonly ICaseFiling _iCaseFiling;
        readonly IRetrievals _iRetrievals;
        Dictionary<String, MscMcomPool> updateStatuQuery = new Dictionary<string, MscMcomPool>();

        public UpdateReponseStatus(ITransactionRepository iTransactionData,
                                   IChargebacks iChargebacks,
                                   IRetrievals iRetrievals,
                                   ICaseFiling iCaseFiling)
        {
            _iTransactionData = iTransactionData;
            _iChargebacks = iChargebacks;
            _iCaseFiling = iCaseFiling;
            _iRetrievals = iRetrievals;
        }

        public void Create(MscMcomPool mscMcomPool)
        {
            var pendingStatuList = _iTransactionData.GetPoolPendingStatu().GroupBy(f => f.ActionType).Select(item => item.ToArray()).ToList();
            foreach (var pendingStatuRecords in pendingStatuList)
            {
                if (pendingStatuRecords.Count() == 0)
                    continue;

                updateStatuQuery.Clear();

                String actionType = pendingStatuRecords.Max(l => l.ActionType);
                if (actionType == ApiConstants.PoolActionType.Chargeback)
                    StatusUpdateChargeback(pendingStatuRecords);
                else if (actionType == ApiConstants.PoolActionType.CaseFilling)
                    StatusUpdateCaseFilling(pendingStatuRecords);
                else if (actionType == ApiConstants.PoolActionType.Retrieval)
                    StatusUpdateRetrieval(pendingStatuRecords);
            }
        }

        private void StatusUpdateRetrieval(MscMcomPool[] pendingStatuRecords)
        {
            List<RetrievalRequest> retrievalRequest = new List<RetrievalRequest>();
            foreach (var item in pendingStatuRecords)
            {
                MscMcomClaim claim = _iTransactionData.GetClaim(item.ProvisionRefKey);
                retrievalRequest.Add(new RetrievalRequest() { claimId = claim.ClaimId, requestId = item.McomRefNo });
                updateStatuQuery.Add(item.McomRefNo, item);
            }

            Dictionary<String, String> statuResult = new Dictionary<string, string>();
            foreach (var item in _iRetrievals.RetrievalFullfilmentStatus(0, retrievalRequest))
            {
                statuResult.Add(item.requestId, item.status);
            }
            UpdatePoolStatu(statuResult);
        }

        private void StatusUpdateCaseFilling(MscMcomPool[] pendingStatuRecords)
        {
            List<CaseIdRequestResponse> caseIdRequestResponse = new List<CaseIdRequestResponse>();
            foreach (var item in pendingStatuRecords)
            {
                caseIdRequestResponse.Add(new CaseIdRequestResponse() { caseId = item.McomRefNo });
                updateStatuQuery.Add(item.McomRefNo, item);
            }

            Dictionary<String, String> statuResult = new Dictionary<string, string>();
            foreach (var item in _iCaseFiling.CaseStatus(0, caseIdRequestResponse))
            {
                statuResult.Add(item.caseId, item.status);
            }
            UpdatePoolStatu(statuResult);
        }

        private void StatusUpdateChargeback(MscMcomPool[] pendingStatuRecords)
        {
            List<ChargebackRequest> chargebackRequest = new List<ChargebackRequest>();
            foreach (var item in pendingStatuRecords)
            {
                MscMcomClaim claim = _iTransactionData.GetClaim(item.ProvisionRefKey);
                chargebackRequest.Add(new ChargebackRequest() { claimId = claim.ClaimId, chargebackId = item.McomRefNo });
                updateStatuQuery.Add(item.McomRefNo, item);
            }

            Dictionary<String, String> statuResult = new Dictionary<string, string>();
            foreach (var item in _iChargebacks.ChargebacksStatus(0, chargebackRequest))
            {
                statuResult.Add(item.chargebackId, item.status);
            }
            UpdatePoolStatu(statuResult);
        }

        private void UpdatePoolStatu(Dictionary<String, String> statuResult)
        {
            List<MscMcomPool> updateStatuList = new List<MscMcomPool>();
            foreach (var item in statuResult)
            {
                var mscMcomPool = updateStatuQuery[item.Key];
                mscMcomPool.ResponseStatus = item.Value;
                if (mscMcomPool.ResponseStatus == ApiConstants.ChargebackResponseStatus.Completed ||
                    mscMcomPool.ResponseStatus == ApiConstants.ChargebackResponseStatus.Failed)
                    mscMcomPool.ResponseStatusDatetime = DateTime.Now;
                updateStatuList.Add(mscMcomPool);
            }
            _iTransactionData.UpdatePoolData(updateStatuList);
        }

    }
}
