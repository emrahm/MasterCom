using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clearing.Msc.Business.MasterCom.Business.Operation;
using Clearing.Msc.Business.MasterCom.Model;
using Moq;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.ModelData;


namespace Clearing.Msc.Business.MasterCom.UnitTest.Business.Operation
{
    [TestFixture]
    public class CreateQueuesTests
    {
        Mock<IQueues> iQueuesMock = new Mock<IQueues>();
        Mock<ITransactionRepository> iTransactionRepositoryMock = new Mock<ITransactionRepository>();

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        [TestCase("USD")]
        [TestCase("GEO")]
        [TestCase("EUR")]
        [TestCase("GBP")]
        [TestCase("TUR")]
        [TestCase("XXX")]
        public void Create_RetrieveQueue_FillInsert(string currencyCode)
        {
            //arrange 
            List<ResponseQueue> responseQueueList = new List<ResponseQueue>();
            responseQueueList.Add(new ResponseQueue 
            {
                acquirerId = "002222",
                acquirerRefNum = "05103246259000000000126",
                primaryAccountNum = "5123432112344321",
                claimId = "200002020654",
                clearingDueDate = "2016-02-11",
                clearingNetwork = "GCMS",
                createDate = "2016-02-11",
                dueDate = "2016-02-11",
                transactionId = "118411681",
                isAccurate = "true",
                isAcquirer = "true",
                isIssuer = "false",
                isOpen = "true",
                issuerId = "00000006195",
                lastModifiedBy = "system",
                lastModifiedDate = "2016-02-11",
                merchantId = "0024038000200",
                progressState = "CB1-4807-O-A-NEW",
                claimType = "Standard",
                claimValue = "25.00 " + currencyCode
            });
            iQueuesMock.Setup(f => f.GetQueues(It.IsAny<long>(), It.IsAny<String>())).Returns(responseQueueList);
            iTransactionRepositoryMock.Setup(f => f.GetQueueData(It.IsAny<MscMcomQueue>())).Returns((MscMcomQueue)null);
            //act
            CreateQueues createQueues = new CreateQueues(iTransactionRepositoryMock.Object, iQueuesMock.Object);
            createQueues.Create(new MscMcomPool());

            //assert

        }
    }
}
