using Clearing.Msc.Business.MasterCom.Business;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Tqr4;
using Smartway.Ocean.Framework.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Operation
{
    public class OMcomLoadTqr4File : SWOperation
    {
        public override void DoJob()
        {
            String fileName = "";
            Tqr4LoadData tqr4LoadData = new Tqr4LoadData(new Tqr4FileParser(new Tqr4FileReader(fileName)),
                                                         new TransactionRepository());
            tqr4LoadData.LoadData();
        }
    }
}
