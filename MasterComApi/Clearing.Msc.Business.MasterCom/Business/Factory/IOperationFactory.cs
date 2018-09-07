using System;

namespace Clearing.Msc.Business.MasterCom.Business.Factory
{
    public interface IOperationFactory
    {
        IOperation GetOperation(string actionType);
    }
}
