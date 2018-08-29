using Clearing.Msc.Business.MasterCom.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Repository
{
    public interface IMscMcomRequestRepository
    {
        Int64 Create(MscMcomRequest mscMcomRequest);
    }
}
