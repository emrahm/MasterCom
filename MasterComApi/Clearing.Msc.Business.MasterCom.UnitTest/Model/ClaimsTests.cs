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
    public class ClaimsTests
    {
        Mock<IApiController> apiController;
        String claimId = "200002020654";

        private ChargebackFillRequest chargebackRequest;
        [SetUp]
        public void SetUp()
        {
            apiController = new Mock<IApiController>();
        }



        [Test]
        public void Create_NewClaim_ReturnClaimNumber()
        {
            //arrange
            apiController.Setup(f => f.Create<ClaimResponse>(It.IsAny<String>(), It.IsAny<ClaimRequest>()))
             .Returns(new ClaimResponse() { claimId = claimId });

            ClaimRequest claimRequest = new ClaimRequest();
            claimRequest.disputedAmount = "100.00";
            claimRequest.disputedCurrency = "USD";
            claimRequest.claimType = "Standard";
            claimRequest.clearingTransactionId = "hqCnaMDqmto4wnL+BSUKSdzROqGJ7YELoKhEvluycwKNg3XTz/faIJhFDkl9hW081B5tTqFFiAwCpcocPdB2My4t7DtSTk63VXDl1CySA8Y";
            //act
            Claims claim = new Claims(apiController.Object);
            var result = claim.CreateClaim(claimRequest);
            //assert
            Assert.That(result, Is.EqualTo(claimId));
        }

        [Test]
        public void Update_NewClaim_ReturnClaimNumber()
        {
            //arrange
            apiController.Setup(f => f.Update<ClaimResponse>(It.IsAny<String>(), null, It.IsAny<ClaimUpdateRequest>()))
            .Returns(new ClaimResponse() { claimId = claimId });

            ClaimUpdateRequest claimRequest = new ClaimUpdateRequest();
            claimRequest.action = "CLOSE";
            claimRequest.closeClaimReasonCode = "10";
            //act
            Claims claim = new Claims(apiController.Object);
            var result = claim.UpdateClaim(claimId, claimRequest);
            //assert
            Assert.That(result, Is.EqualTo(claimId));
        }

        [Test]
        public void Get_Claim_ReturnClaimData()
        { 
            //arrange
            apiController.Setup(f => f.Get<ClaimDetail>(It.IsAny<String>(), null))
           .Returns(new ClaimDetail());
            //act
            Claims claim = new Claims(apiController.Object);
            var result = claim.GetClaim(claimId);
            //assert
            Assert.That(result, Is.TypeOf<ClaimDetail>());
        }
    }
}
