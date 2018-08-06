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
      "/mastercom/v1/claims/{claim-id}/fraud/mastercard", "create" 
      "/mastercom/v1/claims/{claim-id}/fraud/loaddataforfraud", "query" 
     */
    public class Fraud
    {
        private IApiController _apiController;

        public Fraud(IApiController apiController)
        { 
            _apiController = apiController;
        }


        public string CreateForMasterCard(string claimId, FraudRequest fraudRequest)
        {
            return _apiController.Create<FraudResponse>(String.Format("claims/{0}/fraud/mastercard", claimId), fraudRequest).fraudId;
        }
    }
}
