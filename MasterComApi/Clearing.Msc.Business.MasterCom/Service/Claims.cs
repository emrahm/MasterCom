﻿using Clearing.Msc.Business.MasterCom.ModelData;
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
    public class Claims : IClaims
    {
        IApiController _apiController = null;
        public Claims(IApiController apiController)
        {
            _apiController = apiController;
        }

        public String CreateClaim(long refKey, ClaimRequest claimRequest)
        {
            return _apiController.Create<ClaimResponse>(refKey, "claims", claimRequest).claimId;
        }

        public ClaimDetail GetClaim(long refKey, String claimId)
        {
            return _apiController.Get<ClaimDetail>(refKey, String.Format("claims/{0}", claimId), null);
        }

        public String UpdateClaim(long refKey, String claimId, ClaimUpdateRequest claimUpdateRequest)
        {
            return _apiController.Update<ClaimResponse>(refKey, String.Format("claims/{0}", claimId), null, claimUpdateRequest).claimId;
        }
    }
}
