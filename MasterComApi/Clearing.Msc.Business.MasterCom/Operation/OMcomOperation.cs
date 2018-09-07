using Clearing.Msc.Business.MasterCom.Business;
using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.Business.Operation;
using Clearing.Msc.Business.MasterCom.Business.Process;
using Clearing.Msc.Business.MasterCom.Repository;
using Smartway.Ocean.Framework.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Operation
{
    /// <summary>
    /// otomatik olarak devamlı çalıştırılacak.
    /// Process devamlı bitince çalıştırılacak.
    /// </summary>
    public class OMcomOperation : SWOperation
    {
        public override void DoJob()
        { 
            ProcessPool processPool = new ProcessPool(new TransactionRepository(),
                                                      new OperationFactory());
            processPool.Start();
            
            Thread.Sleep(1000);
        }
    }
}
