using MasterCard.Api.Mastercom;
using MasterCard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterComTest
{
    public class RetrieveQueueNamesOperation: MasterComOperation
    {
        protected override void RunOperation()
        {
            List<Queues> responseList = Queues.retrieveQueueNames(); 
        }
    }
}
