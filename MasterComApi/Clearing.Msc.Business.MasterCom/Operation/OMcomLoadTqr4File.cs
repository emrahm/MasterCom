using Clearing.Msc.Business.MasterCom.Business;
using Clearing.Msc.Business.MasterCom.Business.Operation;
using Clearing.Msc.Business.MasterCom.Business.Process;
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
    /// <summary>
    /// TQR4 dosyası yuklenir dosya bir dizine bırakılmalı program o dizinden okuyup gunun  belli saatlerinde otomatik çalışacak.
    /// </summary>
    public class OMcomLoadTqr4File : SWOperation, ISWIndepenentOperation
    {
        public override void DoJob()
        {
            String fileName = "";
            Tqr4LoadData tqr4LoadData = new Tqr4LoadData(new Tqr4FileParser(new Tqr4FileReader(fileName)),
                                                         new TransactionRepository());
            tqr4LoadData.LoadData();
        }

        public Dictionary<string, object> GetOutputParameters()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            return result;
        }

        public void SetInputParameters(Dictionary<string, object> Parameters)
        {
        }
    }
}
