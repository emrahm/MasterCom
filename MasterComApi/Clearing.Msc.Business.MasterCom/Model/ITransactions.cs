using Clearing.Msc.Business.MasterCom.ModelData;
using System;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface ITransactions
    {
        TransactionAuthorization AuthorizationTran(string claimId, string transactionId);
        TransactionClearing ClearingTran(string claimId, string transactionId);
        TransactionSearchResponse Search(TransactionSearchRequest transactionSearchRequest);
    }
}
