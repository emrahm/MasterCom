using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.Business.Operation;
using Clearing.Msc.Business.MasterCom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Process
{
    public class ProcessResponseStatus
    {
        ITransactionRepository _iTransactionRepository;
        IOperationFactory _iOperationFactory;

        public ProcessResponseStatus(ITransactionRepository iTransactionRepository,
                            IOperationFactory iOperationFactory)
        {
            _iTransactionRepository = iTransactionRepository;
            _iOperationFactory = iOperationFactory;
        }

        public void Start()
        {
            ProcessResponseStatus updateReponseStatus = new ProcessResponseStatus(new TransactionRepository(),
                                                                                  new OperationFactory());
            updateReponseStatus.Start();
        }
    }
}
