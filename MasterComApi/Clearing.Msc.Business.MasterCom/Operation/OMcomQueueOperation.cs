using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.Business.Process;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.Repository;
using Smartway.Ocean.Framework.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Operation
{
    /// <summary>
    /// Queue lar alınacak. 08:00, 10:00, 12:00, 14:00, 16:00, 18:00 zamanlarında çalıştırılacak.
    /// </summary>
    public class OMcomQueueOperation : SWOperation, ISWIndepenentOperation
    {
        public override void DoJob()
        {
            StartQueue();
            ProcessStatuUpdate();

        }

        private void ProcessStatuUpdate()
        {
            ProcessResponseStatus updateReponseStatus = new ProcessResponseStatus(new OperationFactory());
            updateReponseStatus.Start();
        }

        private void StartQueue()
        {
            ProcessQueue processQueue = new ProcessQueue(new OperationFactory());
            processQueue.Start();
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
