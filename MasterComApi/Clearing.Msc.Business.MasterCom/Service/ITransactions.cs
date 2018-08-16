using Clearing.Msc.Business.MasterCom.ModelData;
using System;

namespace Clearing.Msc.Business.MasterCom.Model
{
    public interface ITransactions
    {
        TransactionAuthorization AuthorizationTran(long refKey, string claimId, string transactionId);
        TransactionClearing ClearingTran(long refKey, string claimId, string transactionId);
        TransactionSearchResponse Search(long refKey, TransactionSearchRequest transactionSearchRequest);
    }
}
