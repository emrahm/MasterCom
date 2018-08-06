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
    public class ChargebackTests
    {
        String claimId = "12344";
        Mock<IApiController> apiController;
        private ChargebackFillRequest chargebackRequest;

        [SetUp]
        public void SetUp()
        {
            apiController = new Mock<IApiController>();
        }


        [Test]
        public void Ent_Create_GetChargebackId_ReturnChargebackId()
        {
            String chargebackId = "300002063556";
            //assign
            apiController.Setup(f => f.Create<ChargebackResponse>(It.IsAny<String>(), It.IsAny<ChargebackFillRequest>()))
            .Returns(new ChargebackResponse() { chargebackId = chargebackId });

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
            Chargebacks chargeback = new Chargebacks(apiController.Object);
            var result = chargeback.Create(claimId, chargebackRequest);
            //assert
            Assert.That(result, Is.EqualTo(chargebackId));
        }

        [Test]
        public void Ent_CreateReversal_GetChargebackId_ReturnChargebackId()
        {
            String chargebackId = "974455";
            String chargebackReversalId = "974455";

            apiController.Setup(f => f.Create<ChargebackResponse>(It.IsAny<String>(), It.IsAny<ChargebackRequest>()))
            .Returns(new ChargebackResponse() { chargebackId = chargebackReversalId });

            Chargebacks chargeback = new Chargebacks(apiController.Object);
            var result = chargeback.CreateReversal(new ChargebackRequest
            {
                claimId = claimId,
                chargebackId = chargebackId
            });
            //assert
            Assert.That(result, Is.EqualTo(chargebackReversalId));
        }

        [Test]
        public void Ent_RetrieveDocumentation()
        {
            String chargebackId = "974455";
            apiController.Setup(f => f.Get<FileAttachment>(It.IsAny<String>(), It.IsAny<Dictionary<string, string>>()))
             .Returns(new FileAttachment());

            Chargebacks chargeback = new Chargebacks(apiController.Object);
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

            apiController.Setup(f => f.Update<ChargebackResponse>(It.IsAny<String>(), null, It.IsAny<ChargebackFillRequest>()))
            .Returns(new ChargebackResponse() { chargebackId = chargebackId });

            chargebackRequest.memo = "This is a test memo";
            chargebackRequest.fileAttachment.filename = "test.tif";
            chargebackRequest.fileAttachment.file = "sample file";
            Chargebacks chargeback = new Chargebacks(apiController.Object);
            var result = chargeback.Update(new ChargebackRequest
            {
                claimId = claimId,
                chargebackId = chargebackId
            }, chargebackRequest);
            //assert
            Assert.That(result, Is.EqualTo(chargebackId));
        }


        [Test]
        public void Ent_AcknowledgeReceivedChargebacks()
        {
            //arrange
            String chargebackId = "300002063556";
            List<ChargebackRequest> chargebackRequestList = new List<ChargebackRequest>();
            chargebackRequestList.Add(new ChargebackRequest() { claimId = "200002020654", chargebackId = "300002063556" });

            apiController.Setup(f => f.Update<ChargebackAcknowledgeResponse>(It.IsAny<String>(), null, It.IsAny<ChargebackAcknowledgeRequest>()))
            .Returns(new ChargebackAcknowledgeResponse()
                        {
                            chargebackResponseList = new List<ChargebackResponse>
                                                     {
                                                         new ChargebackResponse() { chargebackId = chargebackId }
                                                     }
                        });


            //act
            Chargebacks chargeback = new Chargebacks(apiController.Object);
            var result = chargeback.AcknowledgeReceivedChargebacks(chargebackRequestList);
            //assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].chargebackId, Is.EqualTo(chargebackId));
        }

        [Test]
        public void Ent_ChargebacksStatus()
        {
            //arrange
            String chargebackId = "1234123456";
            List<ChargebackRequest> chargebackRequestList = new List<ChargebackRequest>();
            chargebackRequestList.Add(new ChargebackRequest() { claimId = "12344", chargebackId = chargebackId });

            apiController.Setup(f => f.Update<ChargebackStatusResponseList>(It.IsAny<String>(), null, It.IsAny<ChargebackStatusRequest>()))
            .Returns(new ChargebackStatusResponseList()
            {
                chargebackResponseList = new List<ChargebackStatusResponse>
                {
                    new ChargebackStatusResponse() { chargebackId = chargebackId, status= "COMPLETED" }
                }
            });

            //act
            Chargebacks chargeback = new Chargebacks(apiController.Object);
            var result = chargeback.ChargebacksStatus(chargebackRequestList);
            //assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].status, Is.EqualTo("COMPLETED"));
        }
    }
}
