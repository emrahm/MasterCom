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
    public class ChargebackTests
    {
        String claimId = "12344";

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
        public void Ent_Create_GetChargebackId_ReturnChargebackId()
        {
            //assign
            chargebackRequest = new ChargebackFillRequest();
            chargebackRequest.currency = "USD";
            chargebackRequest.documentIndicator = "true";
            chargebackRequest.messageText = "test message";
            chargebackRequest.amount = "100.00";
            chargebackRequest.fileAttachment.filename = "test.tif";
            chargebackRequest.fileAttachment.file = "sample file";
            chargebackRequest.reasonCode = "4853";
            chargebackRequest.chargebackType = "ARB_CHARGEBACK";
            //act
            Chargebacks chargeback = new Chargebacks(apiController);
            var result = chargeback.Create(claimId, chargebackRequest);
            //assert
            Assert.That(result, Is.EqualTo("300002063556"));
        }

        [Test]
        public void Ent_CreateReversal_GetChargebackId_ReturnChargebackId()
        {
            String chargebackId = "974455";

            Chargebacks chargeback = new Chargebacks(apiController);
            var result = chargeback.CreateReversal(new ChargebackRequest
            {
                claimId = claimId,
                chargebackId = chargebackId
            });
            //assert
            Assert.That(result, Is.EqualTo("300002063556"));
        }

        [Test]
        public void Ent_RetrieveDocumentation()
        {
            String chargebackId = "974455";

            Chargebacks chargeback = new Chargebacks(apiController);
            var result = chargeback.RetrieveDocumentation(new ChargebackRequest
            {
                claimId = claimId,
                chargebackId = chargebackId
            });
            //assert
            Assert.That(result, Is.TypeOf<FileAttachment>());
        }


        [Test]
        public void Ent_Update()
        {
            String chargebackId = "974455";
            chargebackRequest = new ChargebackFillRequest();

            chargebackRequest.memo = "This is a test memo";
            chargebackRequest.fileAttachment.filename = "test.tif";
            chargebackRequest.fileAttachment.file = "sample file";
            Chargebacks chargeback = new Chargebacks(apiController);
            var result = chargeback.Update(new ChargebackRequest
            {
                claimId = claimId,
                chargebackId = chargebackId
            }, chargebackRequest);
            //assert
            Assert.That(result, Is.EqualTo("974455"));
        }


        [Test]
        public void Ent_AcknowledgeReceivedChargebacks()
        {
            List<ChargebackRequest> chargebackRequestList = new List<ChargebackRequest>();
            chargebackRequestList.Add(new ChargebackRequest() { claimId = "200002020654", chargebackId = "300002063556" });
            Chargebacks chargeback = new Chargebacks(apiController);
            var result = chargeback.AcknowledgeReceivedChargebacks(chargebackRequestList);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].chargebackId, Is.EqualTo("300002063556"));
        }

        [Test]
        public void Ent_ChargebacksStatus()
        {
            List<ChargebackRequest> chargebackRequestList = new List<ChargebackRequest>();
            chargebackRequestList.Add(new ChargebackRequest() { claimId = "12344", chargebackId = "1234123456" });
            Chargebacks chargeback = new Chargebacks(apiController);
            var result = chargeback.ChargebacksStatus(chargebackRequestList);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].status, Is.EqualTo("COMPLETED"));
        }
    }
}
