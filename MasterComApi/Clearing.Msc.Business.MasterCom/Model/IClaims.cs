using Clearing.Msc.Business.MasterCom.ModelData;
using System;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface IClaims
    {
        string CreateClaim(ClaimRequest claimRequest);
        ClaimDetail GetClaim(string claimId);
        string UpdateClaim(string claimId, ClaimUpdateRequest claimUpdateRequest);
    }
}
