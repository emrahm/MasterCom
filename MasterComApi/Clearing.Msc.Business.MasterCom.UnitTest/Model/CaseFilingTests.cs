using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Utility;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Model
{
    [TestFixture]
    public class CaseFilingTests
    {
        Mock<IApiController> apiController;
        String caseId = "536092";

        [SetUp]
        public void SetUp()
        {
            apiController = new Mock<IApiController>();
        }

        // {"caseType":"4","chargebackRefNum":["1111423456, 2222123456"],"customerFilingNumber":"5482","violationCode":"D.2","violationDate":"2017-11-13","disputeAmount":"20,.000","currencyCode":"LLL","fileAttachment":{"filename":"test.tif","file":"sample file"},"filedAgainstIca":"004321","filingAs":"A","filingIca":"001234","memo":"This is a test memo"}

        [Test]
        public void CreateCase_GetCaseNumber_ReturnCaseNumber()
        {
            //arrange
            apiController.Setup(f => f.Create<CaseIdRequestResponse>(It.IsAny<String>(), It.IsAny<CaseDetailRequest>()))
                      .Returns(new CaseIdRequestResponse() { caseId = caseId });

            CaseFiling caseFilling = new CaseFiling(apiController.Object);
            //act
            CaseIdRequestResponse caseNumber = caseFilling.CreateCase(new CaseDetailRequest());
            //assert
            Assert.AreEqual(caseNumber.caseId, caseId);
        }

        [Test]
        public void RetrieveDocuments_TakeFiles_Get()
        {
            //arrange
            apiController.Setup(f => f.Get<CaseDetailRetrieveDocument>(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>()))
                .Returns(new CaseDetailRetrieveDocument() { FileAttachment = new FileAttachment() { filename = caseId } });
            //act
            CaseFiling caseFilling = new CaseFiling(apiController.Object);
            var results = caseFilling.RetrieveDocuments(caseId);
            //assert
            Assert.That(results.FileAttachment.filename, Does.Contain(caseId));
        }


        [Test]
        public void UpdateCase_GetCaseNumber_ReturnCaseNumber()
        {
            //arrange
            apiController.Setup(f => f.Update<CaseIdRequestResponse>(It.IsAny<String>(),
                                                                  It.IsAny<Dictionary<String, String>>(),
                                                                  It.IsAny<CaseDetailRequest>()))
             .Returns(new CaseIdRequestResponse { caseId = caseId });
            //act
            CaseFiling caseFilling = new CaseFiling(apiController.Object);
            CaseIdRequestResponse caseNumber = caseFilling.UpdateCase(caseId, new CaseDetailRequest());
            //assert
            Assert.AreEqual(caseNumber.caseId, "536092");
        }


        [Test]
        public void CaseStatus_RequestStatus_ReturnStatus()
        {
            //arrange
            apiController.Setup(f => f.Update<CaseFilingResponseList>(It.IsAny<String>(),
                                                                It.IsAny<Dictionary<String, String>>(),
                                                                It.IsAny<CaseDetailStatus>()))
           .Returns(new CaseFilingResponseList
           {
               caseFilingResponseList = new List<CaseFilingResponse>
               { 
                   new CaseFilingResponse { caseId = caseId } 
               }
           });
            //act
            CaseFiling caseFilling = new CaseFiling(apiController.Object);
            var result = caseFilling.CaseStatus(new List<CaseIdRequestResponse>());
            //assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].caseId, Is.EqualTo(caseId));
        }
    }
}
