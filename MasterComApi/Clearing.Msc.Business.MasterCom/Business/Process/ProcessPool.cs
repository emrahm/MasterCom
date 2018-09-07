using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Process
{
    public class ProcessPool
    {
        ITransactionRepository _iTransactionRepository = null;
        IOperationFactory _iOperationFactory = null; 

        public ProcessPool(ITransactionRepository iTransactionRepository,
                           IOperationFactory iOperationFactory)
        {
            _iTransactionRepository = iTransactionRepository;
            _iOperationFactory = iOperationFactory;
        }

        public void Start()
        {
            
            foreach (MscMcomPool item in _iTransactionRepository.GetPool())
            {
                try
                {
                    IOperation operation = _iOperationFactory.GetOperation(item.ActionType);
                    operation.Create(item);
                    item.ProcessStatus = "C";
                }
                catch (Exception ex)
                {
                    item.ProcessStatus = "E";
                    item.ProcessDescription = ex.Message;
                }
                _iTransactionRepository.UpdatePoolItem(item);
            }
        }
    }
}
