using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
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
    public class TransactionsTests
    {
        String claimId = "200002020654";
        String transactionId = "FIEaEgnM3bwPijwZgjc3Te+Y0ieLbN9ijUugqNSvJmVbO1xs6Jh5iIlmpOpkbax79L8Yj1rBOWBACx+Vj17rzvOepWobpgWNJNdsgHB4ag";

        Mock<IApiController> apiController;
        [SetUp]
        public void SetUp()
        {
            apiController = new Mock<IApiController>();

        }

        [Test]
        public void Search_Search_GetTran()
        {
            //arrange
            TransactionSearchRequest tran = new TransactionSearchRequest();
            tran.acquirerRefNumber = "05436847276000293995738";
            tran.primaryAccountNum = "5488888888887192";
            tran.transAmountFrom = "10000";
            tran.transAmountTo = "20050";
            tran.tranStartDate = "2017-10-01";
            tran.tranEndDate = "2017-10-01";

            apiController.Setup(f => f.Create<TransactionSearchResponse>(It.IsAny<long>(), It.IsAny<String>(), tran))
                      .Returns(new TransactionSearchResponse() { authorizationSummaryCount = "1" });

            //act
            Transactions transaction = new Transactions(apiController.Object);
            var result = transaction.Search(0, tran);
            //assert
            Assert.That(result.authorizationSummaryCount, Is.EqualTo("1"));
            Assert.That(result, Is.TypeOf<TransactionSearchResponse>());
        }

        [Test]
        public void ClearingTran_ShouldReturn()
        {
            apiController.Setup(f => f.Get<TransactionClearing>(It.IsAny<long>(), It.IsAny<String>(), null))
                .Returns(new TransactionClearing() { transactionType = "Clearing" });

            Transactions transaction = new Transactions(apiController.Object);
            var result = transaction.ClearingTran(0, claimId, transactionId);
            Assert.That(result, Is.TypeOf<TransactionClearing>());
            Assert.That(result.transactionType, Is.EqualTo("Clearing"));
        }

        [Test]
        public void AuthTran_ShouldReturn()
        {
            apiController.Setup(f => f.Get<TransactionAuthorization>(It.IsAny<long>(), It.IsAny<String>(), null))
               .Returns(new TransactionAuthorization() { transactionType = "Authorization" });

            Transactions transaction = new Transactions(apiController.Object);
            var result = transaction.AuthorizationTran(0, claimId, transactionId);
            Assert.That(result, Is.TypeOf<TransactionAuthorization>());
            Assert.That(result.transactionType, Is.EqualTo("Authorization"));
        }

    }
}
