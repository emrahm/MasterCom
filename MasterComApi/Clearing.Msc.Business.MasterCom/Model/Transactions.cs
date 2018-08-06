using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Model
{
    /*
        "/mastercom/v1/claims/{claim-id}/transactions/clearing/{transaction-id}", "read"
        "/mastercom/v1/claims/{claim-id}/transactions/authorization/{transaction-id}", "read"
        "/mastercom/v1/transactions/search", "create"
     */
    public class Transactions : ITransactions
    {
        IApiController _apiController = null;
        public Transactions(IApiController apiController)
        {
            _apiController = apiController;
        }
        /// <summary>
        /// 
        /// </summary>
        public TransactionSearchResponse Search(TransactionSearchRequest transactionSearchRequest)
        {
            return _apiController.Create<TransactionSearchResponse>("transactions/search", transactionSearchRequest);
        }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="claimId"></param>
         /// <param name="transactionId"></param>
         /// <returns></returns>
        public TransactionClearing ClearingTran(String claimId, String transactionId)
        {
            return _apiController.Get<TransactionClearing>(String.Format("claims/{0}/transactions/clearing/{1}", claimId, transactionId), null);
        }

        public TransactionAuthorization AuthorizationTran(String claimId, String transactionId)
        {
            return _apiController.Get<TransactionAuthorization>(String.Format("claims/{0}/transactions/authorization/{1}", claimId, transactionId), null);
        } 
    }
}
