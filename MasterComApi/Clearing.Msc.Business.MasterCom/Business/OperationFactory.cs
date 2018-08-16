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

namespace Clearing.Msc.Business.MasterCom.Business
{
    public class OperationFactory : Clearing.Msc.Business.MasterCom.Business.IOperationFactory
    {
        static IApiController _iApiController = null;
        static CreateChargeback _createChargeback = null; 

        public IOperation GetOperation(String actionType)
        {
            switch (actionType)
            {
                case "CB":
                    return GetCreateChargeback();
                default:
                    return null;
            }
        }

        private static IOperation GetCreateChargeback()
        {
            if (_createChargeback == null)
            {
                _createChargeback = new CreateChargeback(new TransactionRepository(),
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
                                                  new RestyClient(new MscMcomRequestRepository()));
            }
            return _iApiController;
        }
    }
}
