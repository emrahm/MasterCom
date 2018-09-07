using Clearing.Msc.Business.MasterCom.Business.Operation;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Security;
using Clearing.Msc.Business.MasterCom.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Factory
{
    public class OperationFactory : IOperationFactory
    {
        static IApiController _iApiController = null;
        static CreateQueues _createQueues = null;
        static CreateIssuerChargeback _createChargeback = null;
        static CreateIssuerChargebackReversal _createChargebackReversal = null;
        static UpdateReponseStatus _UpdateReponseStatus = null;

        public IOperation GetOperation(String actionType)
        {
            switch (actionType)
            {
                case ApiConstants.PoolActionType.Chargeback:
                    return GetCreateChargeback(); 
                case ApiConstants.PoolActionType.ChargebackReversal:
                    return GetCreateChargebackReversal();
                case ApiConstants.PoolActionType.Queues:
                    return GetCreateQueues();
                case ApiConstants.PoolActionType.ResponseStatusUpdate:
                    return GetResponseStatusUpdate();
                default:
                    return null;
            }
        }

        private IOperation GetResponseStatusUpdate()
        {
            if (_UpdateReponseStatus == null)
            {
                _UpdateReponseStatus = new UpdateReponseStatus(new TransactionRepository(),
                                                               new Chargebacks(GetApiController()),
                                                               new Retrievals(GetApiController()),
                                                               new CaseFiling(GetApiController()));
            }
            return _UpdateReponseStatus;
        }

        private IOperation GetCreateQueues()
        {
            if (_createQueues == null)
            {
                _createQueues = new CreateQueues(new TransactionRepository(),
                                                 new Queues(GetApiController()));
            }
            return _createQueues;
        }

        private IOperation GetCreateChargebackReversal()
        {
            if (_createChargebackReversal == null)
            {
                _createChargebackReversal = new CreateIssuerChargebackReversal(new TransactionRepository(),
                                                                         new Chargebacks(GetApiController()));
            }
            return _createChargebackReversal;
        }

        private static IOperation GetCreateChargeback()
        {
            if (_createChargeback == null)
            {
                _createChargeback = new CreateIssuerChargeback(new TransactionRepository(),
                                                   new Transactions(GetApiController()),
                                                   new Claims(GetApiController()),
                                                   new Chargebacks(GetApiController()));
            }
            return _createChargeback;
        }

        private static IApiController GetApiController()
        {
            if (_iApiController == null)
            {
                IMComConfigRepository iMComConfigRepository = new MComConfigRepository();
                _iApiController = new ApiController(iMComConfigRepository.GetMComConfig(),
                                                  new OAuthAuthentication(iMComConfigRepository.GetMComConfig(),
                                                                          new CerteficateReader(),
                                                                          SecurityProtocolType.Tls12),
                                                  new RestyClient(new MscMcomRequestRepository(),
                                                                  new RestClient()));
            }
            return _iApiController;
        }
    }
}
