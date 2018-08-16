using Clearing.Msc.Business.MasterCom.Business;
using Clearing.Msc.Business.MasterCom.Repository;
using Smartway.Ocean.Framework.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Operation
{
    public class OMcomOperation : SWOperation
    {
        public override void DoJob()
        { 
            ProcessPool processPool = new ProcessPool(new TransactionRepository(),
                                                      new OperationFactory());
            processPool.Start();
        }
    }
}
