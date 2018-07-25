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
        int caseNumber = 12;

        [SetUp]
        public void SetUp()
        {
            apiController = new Mock<IApiController>(); 
            apiController.Setup(f => f.Create<int>(It.IsAny<String>(), It.IsAny<CaseDetailRequest>()))
                         .Returns(caseNumber);
        }

       // {"caseType":"4","chargebackRefNum":["1111423456, 2222123456"],"customerFilingNumber":"5482","violationCode":"D.2","violationDate":"2017-11-13","disputeAmount":"20,.000","currencyCode":"LLL","fileAttachment":{"filename":"test.tif","file":"sample file"},"filedAgainstIca":"004321","filingAs":"A","filingIca":"001234","memo":"This is a test memo"}

        [Test]
        public void CreateCase_GetCaseNumber_ReturnCaseNumber()
        {
            //arrange

            //act

            //assert

        }
    }
}
