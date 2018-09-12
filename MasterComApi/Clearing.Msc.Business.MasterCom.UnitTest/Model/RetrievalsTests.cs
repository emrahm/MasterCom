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
    public class RetrievalsTests
    {
        String claimId = "200002020654";

        Mock<IApiController> apiController;

        [SetUp]
        public void SetUp()
        {
            apiController = new Mock<IApiController>();
        }


        [Test]
        public void CreateRetrieval_Create_GetRequestId()
        {
            //arrange
            String requestId = "300002296235";
            RetrievalCreateRequest retrievalCreateRequest = new RetrievalCreateRequest();
            retrievalCreateRequest.retrievalRequestReason = "6343";
            retrievalCreateRequest.docNeeded = "2";

            apiController.Setup(f => f.Create<RetrievalResponse>(It.IsAny<long>(), It.IsAny<String>(), retrievalCreateRequest))
               .Returns(new RetrievalResponse() { requestId = requestId });

            //act
            Retrievals retrievals = new Retrievals(apiController.Object);
            String result = retrievals.CreateRetrieval(0, claimId, retrievalCreateRequest);
            //assert
            Assert.That(result, Is.EqualTo(requestId));
        }

        [Test]
        public void AcquirerFulfillARequest_Fullfillment_GetRequestId()
        {
            //arrange
            String requestId = "2000020";
            RetrievalFulfillmentRequest retrievalFulfillmentRequest = new RetrievalFulfillmentRequest();
            retrievalFulfillmentRequest.acquirerResponseCd = "D";
            retrievalFulfillmentRequest.docTypeIndicator = "2";
            retrievalFulfillmentRequest.memo = "This is an example of what a memo could contain";
            retrievalFulfillmentRequest.fileAttachment.filename = "test.tif";
            retrievalFulfillmentRequest.fileAttachment.file = "sample file";

            apiController.Setup(f => f.Create<RetrievalResponse>(It.IsAny<long>(), It.IsAny<String>(), retrievalFulfillmentRequest))
                .Returns(new RetrievalResponse() { requestId = requestId });
            //act
            Retrievals retrievals = new Retrievals(apiController.Object);
            String result = retrievals.AcquirerFulfillRequest(0, claimId, requestId, retrievalFulfillmentRequest);
            //assert
            Assert.That(result, Is.EqualTo(requestId));


        }

        [Test]
        public void issuerRespondToFulfillment_ResponseFullfilment_GetRequestId()
        {
            //arrange
            String requestId = "2000020";
            RetrievalResponseFulfillmentRequest retrievalResponseFulfillmentRequest = new RetrievalResponseFulfillmentRequest();
            retrievalResponseFulfillmentRequest.issuerResponseCd = "APPROVE";
            retrievalResponseFulfillmentRequest.memo = "This is an example of what a memo could contain";
            retrievalResponseFulfillmentRequest.rejectReasonCd = "A";

            apiController.Setup(f => f.Create<RetrievalResponse>(It.IsAny<long>(), It.IsAny<String>(), retrievalResponseFulfillmentRequest))
            .Returns(new RetrievalResponse() { requestId = requestId });
            //act
            Retrievals retrievals = new Retrievals(apiController.Object);
            String result = retrievals.IssuerRespondToFulfillment(0, claimId, requestId, retrievalResponseFulfillmentRequest);
            //assert
            Assert.That(result, Is.EqualTo(requestId));

        }

        [Test]
        public void GetDocument_RetrieveDocument_File()
        {
            //arrange
            string requestId = "100663292";

            apiController.Setup(f => f.Get<FileAttachment>(It.IsAny<long>(), It.IsAny<String>(), It.IsAny<Dictionary<String, String>>()))
            .Returns(new FileAttachment());

            //act
            Retrievals retrievals = new Retrievals(apiController.Object);
            FileAttachment result = retrievals.GetDocumentation(0, claimId, requestId);
            //assert
            Assert.That(result, Is.TypeOf<FileAttachment>());
        }

        [Test]
        public void GetDocument_Status_ReturnStatu()
        {  
           //arrange
            String requestId = "1234123456";
            List<RetrievalRequest> retrievalRequestList = new List<RetrievalRequest>();
            retrievalRequestList.Add(new RetrievalRequest() { claimId = "12344",  requestId = requestId });

            apiController.Setup(f => f.Update<RetrievalResponseList>(It.IsAny<long>(), It.IsAny<String>(), null, It.IsAny<RetrievalRequestList>()))
            .Returns(new RetrievalResponseList()
            { 
                RetrievalResponse = new List<RetrievalResponse>
                {
                    new RetrievalResponse() { requestId = requestId, status= "COMPLETED" }
                }
            });

            //act
            Retrievals retrievals = new Retrievals(apiController.Object);
            var result = retrievals.RetrievalFullfilmentStatus(0, retrievalRequestList);
            //assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].status, Is.EqualTo("COMPLETED"));
        }
    }
}
