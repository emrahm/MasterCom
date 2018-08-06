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
    public class FraudTests
    {
        IApiController apiController = null;

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
        public void CreateFraud_Fraud_GetFraudId()
        {
            //       RequestMap map = new RequestMap();
            //map.set("claim-id", "200002020654");

            //Fraud response = Fraud.createForMasterCard(map);

            //out(response, "fraudId"); //-->300002292548

            //arrange
            String claimId = "200002020654";
            FraudRequest fraudRequest = new FraudRequest();
            fraudRequest.deviceType = "1";
            fraudRequest.acctStatus = "ACCT_IS_OPEN";
            fraudRequest.reportDate = "2017-02-11";
            fraudRequest.fraudType = "00";
            fraudRequest.subType = "K";
            fraudRequest.cvcInvalidIndicator = "Y";
            fraudRequest.chgbkIndicator = "1";
            //act
            Fraud fraudData = new Fraud(apiController);
            String result = fraudData.CreateForMasterCard(claimId, fraudRequest);
            //assert
            Assert.That(result, Is.EqualTo("300002292548"));
        }

    }
}
