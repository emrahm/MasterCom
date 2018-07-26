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
    public class TransactionsTests
    {
        String claimId = "200002020654";
        String transactionId = "FIEaEgnM3bwPijwZgjc3Te+Y0ieLbN9ijUugqNSvJmVbO1xs6Jh5iIlmpOpkbax79L8Yj1rBOWBACx+Vj17rzvOepWobpgWNJNdsgHB4ag";

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
            //act
            Transactions transaction = new Transactions(apiController);
            var result = transaction.Search(tran);
            //assert
            Assert.That(result.authorizationSummaryCount, Is.EqualTo("1"));
        }

        [Test]
        public void ClearingTran_ShouldReturn()
        {
            Transactions transaction = new Transactions(apiController);
            var result = transaction.ClearingTran(claimId, transactionId);
            Assert.That(result, Is.TypeOf<TransactionClearing>());
            Assert.That(result.transactionType, Is.EqualTo("Clearing"));
        }

        [Test]
        public void AuthTran_ShouldReturn()
        {
            Transactions transaction = new Transactions(apiController);
            var result = transaction.AuthorizationTran(claimId, transactionId);
            Assert.That(result, Is.TypeOf<TransactionAuthorization>());
            Assert.That(result.transactionType, Is.EqualTo("Authorization"));
        }

    }
}
