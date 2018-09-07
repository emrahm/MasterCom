using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Operation
{
    public class CreateQueues : IOperation
    {
        private ITransactionRepository _transactionRepository;
        private IQueues _iQueues;

        public CreateQueues(ITransactionRepository transactionRepository, IQueues iQueues)
        {
            _transactionRepository = transactionRepository;
            _iQueues = iQueues;
        }

        public void Create(MscMcomPool mscMcomPool)
        {
            ProcessQueues("CHARGEBACK", mscMcomPool);
        }

        private void ProcessQueues(string queueName, MscMcomPool mscMcomPool)
        {
            List<MscMcomQueue> mscMcomQueueList = new List<MscMcomQueue>();
            foreach (var responseQueue in _iQueues.GetQueues(mscMcomPool.ClearingRefKey, queueName))
            {
                var mscMcomQueueResponse = GetQueueData(queueName, responseQueue);
                MscMcomQueue mscMcomQueue = _transactionRepository.GetQueueData(mscMcomQueueResponse);
                if (mscMcomQueue == null)
                    mscMcomQueueList.Add(mscMcomQueueResponse);
            }
            _transactionRepository.CreateQueueData(mscMcomQueueList);
        }

        private MscMcomQueue GetQueueData(String queueName, ResponseQueue responseQueue)
        {
            MscMcomQueue mscMcomQueue = new MscMcomQueue();
            mscMcomQueue.AcquirerId = responseQueue.acquirerId;
            mscMcomQueue.Arn = responseQueue.acquirerRefNum;
            mscMcomQueue.CardNo = responseQueue.primaryAccountNum;
            mscMcomQueue.ClaimId = responseQueue.claimId;
            mscMcomQueue.ClaimType = responseQueue.claimType;
            mscMcomQueue.ClaimAmount = Convert.ToDecimal(responseQueue.claimValue.Split(' ')[0], CultureInfo.GetCultureInfo("en-US"));
            mscMcomQueue.ClaimCurrency = GetCurrencyCode(responseQueue.claimValue.Split(' ')[1]);
            mscMcomQueue.ClearingDueDate = DateTime.ParseExact(responseQueue.clearingDueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            mscMcomQueue.ClearingNetwork = responseQueue.clearingNetwork;
            mscMcomQueue.CreateDate = DateTime.ParseExact(responseQueue.createDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            mscMcomQueue.DueDate = DateTime.ParseExact(responseQueue.dueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            mscMcomQueue.TransactionId = responseQueue.transactionId;
            mscMcomQueue.IsAccurate = Convert.ToBoolean(responseQueue.isAccurate);
            mscMcomQueue.IsAcquirer = Convert.ToBoolean(responseQueue.isAcquirer);
            mscMcomQueue.IsIssuer = Convert.ToBoolean(responseQueue.isIssuer);
            mscMcomQueue.IsOpen = Convert.ToBoolean(responseQueue.isOpen);
            mscMcomQueue.IssuerId = responseQueue.issuerId;
            mscMcomQueue.LastModifiedBy = responseQueue.lastModifiedBy;
            mscMcomQueue.LastModifiedDate = DateTime.ParseExact(responseQueue.lastModifiedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            mscMcomQueue.MerchantId = responseQueue.merchantId;
            mscMcomQueue.ProgressState = responseQueue.progressState;
            mscMcomQueue.QueueName = queueName;
            mscMcomQueue.ProcessedStatus = "N";
            mscMcomQueue.ProcessedDate = DateTime.ParseExact("19000101", "yyyyMMdd", CultureInfo.InvariantCulture);
            mscMcomQueue.InsertDate = DateTime.Now;
            mscMcomQueue.InsertTime = Convert.ToInt32(DateTime.Now.ToString("hhMMss"));
            return mscMcomQueue;
        }

        private string GetCurrencyCode(string currencyCode)
        {
            if (currencyCode == "USD")
                return "840";
            else if (currencyCode == "GEO")
                return "268";
            else if (currencyCode == "EUR")
                return "978";
            else if (currencyCode == "GBP")
                return "826";
            else if (currencyCode == "TUR")
                return "949";
            else
                return currencyCode;
        }
    }
}
