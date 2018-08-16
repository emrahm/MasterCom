using Clearing.Msc.Business.MasterCom.ModelData;
using System;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface IFraud
    {
        string CreateForMasterCard(long refKey, string claimId, FraudRequest fraudRequest);
    }
}
