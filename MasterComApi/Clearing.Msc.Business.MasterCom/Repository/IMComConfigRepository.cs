using Clearing.Msc.Business.MasterCom.DbObjects;
using System;

namespace Clearing.Msc.Business.MasterCom.Repository
{
    public interface IMComConfigRepository
    {
        MscMcomConfig GetMComConfig();
    }
}
