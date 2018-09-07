using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Utility; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Process
{
    public class ProcessQueue
    {
        ITransactionRepository _iTransactionRepository;
        IOperationFactory _iOperationFactory;

        public ProcessQueue(ITransactionRepository iTransactionRepository,
                            IOperationFactory iOperationFactory)
        {
            _iTransactionRepository = iTransactionRepository;
            _iOperationFactory = iOperationFactory;
        }

        public void Start()
        {
            MscMcomPool mscMcomPool = new MscMcomPool();
            mscMcomPool.ClearingRefKey = 0;
            mscMcomPool.ActionType = ApiConstants.PoolActionType.Queues;
            IOperation operation = _iOperationFactory.GetOperation(mscMcomPool.ActionType);
            operation.Create(mscMcomPool);
        }
    }
}
