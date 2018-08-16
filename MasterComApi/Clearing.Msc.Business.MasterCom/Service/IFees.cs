using Clearing.Msc.Business.MasterCom.ModelData;
using System;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface IFees
    {
        string CreateFee(long refKey, string claimId, FeeDetail feeDetail);
    }
}
