using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Security;
using Clearing.Msc.Business.MasterCom.Utility;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.EntegrationTest.Model
{
    [TestFixture]
    public class FeeTests
    {
        IApiController apiController = null;
        private FeeDetail feeDetail;
        [SetUp]
        public void SetUp()
        {

            IMComConfigRepository iMComConfigRepository = new MComConfigRepository();
            apiController = new ApiController(iMComConfigRepository.GetMComConfig(),
                                              new OAuthAuthentication(iMComConfigRepository.GetMComConfig(),
                                                                      new CerteficateReader(),
                                                                      SecurityProtocolType.Tls12),
                                              new RestClient());

        }

        [Test]
        public void Ent_CreateFee_CreateFee_FeeId()
        {
            //arrange
            String claimId = "200002020654";
            String feeId = "20002052146";
            feeDetail = new FeeDetail();
            feeDetail.cardAcceptorIdCode = "123456789012345";
            feeDetail.cardNumber = "500000000001234";
            feeDetail.countryCode = "USA";
            feeDetail.currency = "USD";
            feeDetail.feeDate = "2017-02-11";
            feeDetail.destinationMember = "002083";
            feeDetail.feeAmount = "100.00";
            feeDetail.creditSender = "true";
            feeDetail.creditReceiver = "false";
            feeDetail.message = "This is a test message";
            feeDetail.reason = "7604"; 
            //act
            Fees fee = new Fees(apiController);
            var result = fee.CreateFee(claimId, feeDetail);
            //assert
            Assert.That(result, Is.EqualTo(feeId));
        }

    }
}
