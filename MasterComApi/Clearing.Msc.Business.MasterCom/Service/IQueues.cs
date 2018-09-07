using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Model
{
    public interface IQueues
    {
        List<ResponseQueue> GetQueues(long refKey, string queueName);
    }
}
