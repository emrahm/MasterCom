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
    public class RetrievalsTests
    {
        String claimId = "200002020654";
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
        public void CreateRetrieval_Create_GetRequestId()
        {
            //arrange
            RetrievalCreateRequest retrievalCreateRequest = new RetrievalCreateRequest();
            retrievalCreateRequest.retrievalRequestReason = "6343";
            retrievalCreateRequest.docNeeded = "2";
            //act
            Retrievals retrievals = new Retrievals(apiController);
            String result = retrievals.CreateRetrieval(claimId, retrievalCreateRequest);
            //assert
            Assert.That(result, Is.EqualTo("300002296235"));
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
            //act
            Retrievals retrievals = new Retrievals(apiController);
            String result = retrievals.AcquirerFulfillRequest(claimId, requestId, retrievalFulfillmentRequest);
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
            //act
            Retrievals retrievals = new Retrievals(apiController);
            String result = retrievals.IssuerRespondToFulfillment(claimId, requestId, retrievalResponseFulfillmentRequest);
            //assert
            Assert.That(result, Is.EqualTo("300002296235"));

        }

        [Test]
        public void GetDocument_RetrieveDocument_File()
        {
            //arrange
            string requestId = "100663292";
            //act
            Retrievals retrievals = new Retrievals(apiController);
            FileAttachment result = retrievals.GetDocumentation(claimId, requestId);
            //assert
              Assert.That(result.file, Is.EqualTo("RT_100663292.zip"));
        }
    }
}
