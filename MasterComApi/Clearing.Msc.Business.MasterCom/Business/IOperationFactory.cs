using System;

namespace Clearing.Msc.Business.MasterCom.Business
{
    public interface IOperationFactory
    {
        IOperation GetOperation(string actionType);
    }
}
