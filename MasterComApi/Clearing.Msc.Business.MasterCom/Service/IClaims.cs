using Clearing.Msc.Business.MasterCom.ModelData;
using System;

namespace Clearing.Msc.Business.MasterCom.Model
{
    public interface IClaims
    {
        string CreateClaim(long refKey, ClaimRequest claimRequest);
        ClaimDetail GetClaim(long refKey, string claimId);
        string UpdateClaim(long refKey, string claimId, ClaimUpdateRequest claimUpdateRequest);
    }
}
