using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Security;
using Clearing.Msc.Business.MasterCom.Utility;
using Moq;
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
        Mock<IApiController> apiController;

        [SetUp]
        public void SetUp()
        {
            apiController = new Mock<IApiController>();
        }


        [Test]
        public void CreateFraud_Fraud_GetFraudId()
        {
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

            apiController.Setup(f => f.Create<FraudResponse>(It.IsAny<long>(), It.IsAny<String>(), fraudRequest))
                .Returns(new FraudResponse() { fraudId = "300002292548" });
            //act
            Fraud fraudData = new Fraud(apiController.Object);
            String result = fraudData.CreateForMasterCard(0, claimId, fraudRequest);
            //assert
            Assert.That(result, Is.EqualTo("300002292548"));
        }

    }
}
