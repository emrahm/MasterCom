using Clearing.Msc.Business.MasterCom.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Factory
{
    public interface IOperation
    {
        void Create(MscMcomPool mscMcomPool);
    }
}
