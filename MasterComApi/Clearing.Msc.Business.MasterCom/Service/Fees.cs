using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Model
{
    /// <summary>
    ///  "/mastercom/v1/claims/{claim-id}/fee", "create" 
    /// "/mastercom/v1/claims/{claim-id}/fees/loaddataforfees", "query" 
    /// </summary>
    public class Fees : IFees
    {
        IApiController _apiController = null;
        public Fees(IApiController apiController)
        {
            _apiController = apiController;
        }

        public String CreateFee(String claimId, FeeDetail feeDetail)
        {
            return _apiController.Create<FeeDetail>(String.Format("claims/{0}/fee", claimId), feeDetail).feeId;
        }
    }
}
