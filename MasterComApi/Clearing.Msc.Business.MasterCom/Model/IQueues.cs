using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface IQueues
    {
        List<ResponseQueue> GetQueues(string queueName);
    }
}
