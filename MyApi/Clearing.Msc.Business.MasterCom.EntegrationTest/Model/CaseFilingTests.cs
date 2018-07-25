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

namespace Clearing.Msc.Business.MasterCom.UnitTest.Model
{
    [TestFixture]
    public class CaseFilingTests
    {
        //arrange
        String caseId = "536092";
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

        // {"caseType":"4","chargebackRefNum":["1111423456, 2222123456"],"customerFilingNumber":"5482","violationCode":"D.2","violationDate":"2017-11-13","disputeAmount":"20,.000","currencyCode":"LLL","fileAttachment":{"filename":"test.tif","file":"sample file"},"filedAgainstIca":"004321","filingAs":"A","filingIca":"001234","memo":"This is a test memo"}

        [Test]
        public void Ent_CreateCase_GetCaseNumber_ReturnCaseNumber()
        {
            //arrange
            CaseFiling caseFilling = new CaseFiling(apiController);
            CaseDetailRequest caseDetail = new CaseDetailRequest();
            caseDetail.caseType = "4";
            caseDetail.chargebackRefNum.Add("1111423456");
            caseDetail.chargebackRefNum.Add("2222123456");
            caseDetail.customerFilingNumber = "5482";
            caseDetail.violationCode = "D.2";
            caseDetail.violationDate = "2017-11-13";
            caseDetail.disputeAmount = "200.00";
            caseDetail.currencyCode = "USD";
            caseDetail.fileAttachment.filename = "test.tif";
            caseDetail.fileAttachment.file = "sample file";
            caseDetail.filedAgainstIca = "004321";
            caseDetail.filingAs = "A";
            caseDetail.filingIca = "001234";
            caseDetail.memo = "This is a test memo";
            //act
            CaseIdRequestResponse caseNumber = caseFilling.CreateCase(caseDetail);
            //assert
            Assert.AreEqual(caseNumber.caseId, "536092");
        }

        [Test]
        public void Ent_UpdateCase_GetCaseNumber_ReturnCaseNumber()
        {
            //arrange
            CaseFiling caseFilling = new CaseFiling(apiController);
            CaseDetailRequest caseDetail = new CaseDetailRequest();
            caseDetail.fileAttachment.filename = "test.tif";
            caseDetail.fileAttachment.file = "sample file";
            caseDetail.memo = "This is a test memo";
            caseDetail.action = "REJECT";
            //act
            CaseIdRequestResponse caseNumber = caseFilling.UpdateCase(caseId, caseDetail);
            //assert
            Assert.AreEqual(caseNumber.caseId, "536092");
        }

        [Test]
        public void Ent_CaseStatus_RequestStatus_ReturnStatus()
        {
            //arrange
            CaseFiling caseFilling = new CaseFiling(apiController);
            List<CaseIdRequestResponse> caseIdList = new List<CaseIdRequestResponse>();
            caseIdList.Add(new CaseIdRequestResponse() { caseId = caseId });
            //act
            var result = caseFilling.CaseStatus(caseIdList);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].caseId, Is.EqualTo(caseId));
        }

        [Test]
        public void Ent_RetrieveDocuments_TakeFiles_Get()
        {

            //act
            CaseFiling caseFilling = new CaseFiling(apiController);
            var results = caseFilling.RetrieveDocuments(caseId);
            //assert
            Assert.That(results.FileAttachment.filename, Does.Contain(caseId));
        }
    }
}
