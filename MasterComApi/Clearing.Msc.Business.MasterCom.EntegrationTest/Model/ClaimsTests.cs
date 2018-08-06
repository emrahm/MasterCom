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
    public class ClaimsTests
    {
        IApiController apiController = null;
        private ChargebackFillRequest chargebackRequest;
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
        public void Ent_Create_NewClaim_ReturnClaimNumber()
        {
            //arrange
            ClaimRequest claimRequest = new ClaimRequest();
            claimRequest.disputedAmount = "100.00";
            claimRequest.disputedCurrency = "USD";
            claimRequest.claimType = "Standard";
            claimRequest.clearingTransactionId = "hqCnaMDqmto4wnL+BSUKSdzROqGJ7YELoKhEvluycwKNg3XTz/faIJhFDkl9hW081B5tTqFFiAwCpcocPdB2My4t7DtSTk63VXDl1CySA8Y";
            //act
            Claims claim = new Claims(apiController);
            var result = claim.CreateClaim(claimRequest);
            //assert
            Assert.That(result, Is.EqualTo("200002020654"));
        }

        [Test]
        public void Ent_Update_NewClaim_ReturnClaimNumber()
        {
            //arrange
            String claimId = "200002020654";
            ClaimUpdateRequest claimRequest = new ClaimUpdateRequest();
            claimRequest.action = "CLOSE";
            claimRequest.closeClaimReasonCode = "10";
            //act
            Claims claim = new Claims(apiController);
            var result = claim.UpdateClaim(claimId, claimRequest);
            //assert
            Assert.That(result, Is.EqualTo("200002020654"));  
        }

        [Test]
        public void Ent_Get_Claim_ReturnClaimData()
        {
            //arrange
            String claimId = "200002020654";
            //act
            Claims claim = new Claims(apiController);
            var result = claim.GetClaim(claimId);
            //assert
            Assert.That(result, Is.TypeOf<ClaimDetail>());
        }
    }
}
