using MasterCard.Api.Mastercom;
using MasterCard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterComTest
{
    public class RetrieveClaimsFromQueueOperation : MasterComOperation
    {
        protected override void RunOperation()
        {
            RequestMap map = new RequestMap();
            map.Set("queue-name", "Closed");

            foreach (var item in Queues.retrieveClaimsFromQueue(map))
                RetrieveData(item);
        }

        private void RetrieveData(SmartMap item)
        {
            String acquirerId = item["acquirerId"].ToString();
        }
    }
}
