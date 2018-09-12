using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Operation
{
    /// <summary>
    /// Chargeback butonuna basıldıgında bu operasyon çağırılacak.
    /// Senkron veya asenkron durumuna göre kayıtlar 
    /// </summary>
    public class OMComCreateServiceRequest
    {
        Boolean _isBatch = false;
        ITransactionRepository _iTransactionRepository = null;
        IMComConfigRepository _iMComConfigRepository = null;
        IOperationFactory _iOperationFactory = null;

        public OMComCreateServiceRequest(ITransactionRepository iTransactionRepository,
                                         IMComConfigRepository iMComConfigRepository,
                                         IOperationFactory iOperationFactory,
                                         Boolean isBatch)
        {
            _isBatch = isBatch;
            _iTransactionRepository = iTransactionRepository;
            _iOperationFactory = iOperationFactory;
            _iMComConfigRepository = iMComConfigRepository;
        }

        public void Create(MscMcomPool mscMcomPool)
        {
            MscMcomConfig mscMcomConfig = _iMComConfigRepository.GetMComConfig();
            mscMcomPool.IsAsynchronous = true;
            mscMcomPool.ProcessStatus = "S";
            mscMcomPool.ResponseStatus = "INITIAL";

            if(mscMcomConfig.IsSynchronized)
                mscMcomPool.IsAsynchronous = !mscMcomConfig.IsSynchronized;

            if(_isBatch)
                mscMcomPool.IsAsynchronous = !mscMcomConfig.IsBatchSynchronized;

            if (!mscMcomPool.IsAsynchronous)
            {
                IOperation operation = _iOperationFactory.GetOperation(mscMcomPool.ActionType);
                operation.Create(mscMcomPool);
                mscMcomPool.ProcessStatus = "C";
            }
            _iTransactionRepository.CreatePoolItem(mscMcomPool);
        }
    }
}
