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
    ///  "/mastercom/v1/claims", "create" 
    ///  "/mastercom/v1/claims/{claim-id}", "read" 
    ///  "/mastercom/v1/claims/{claim-id}", "update" 
    /// </summary>
    public class Claims
    {
        IApiController _apiController = null;
        public Claims(IApiController apiController)
        {
            _apiController = apiController;
        }

        public String CreateClaim(ClaimRequest claimRequest)
        {
            return _apiController.Create<ClaimResponse>("claims", claimRequest).claimId;
        }

        public ClaimDetail GetClaim(String claimId)
        {
            return _apiController.Get<ClaimDetail>(String.Format("claims/{0}", claimId), null);
        }

        public String UpdateClaim(String claimId, ClaimUpdateRequest claimUpdateRequest)
        {
            return _apiController.Update<ClaimResponse>(String.Format("claims/{0}", claimId), null, claimUpdateRequest).claimId;
        }
    }
}
