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
    public class QueuesTests
    {
        Mock<IApiController> apiController;
        List<ResponseQueue> returnList = new List<ResponseQueue>();  
        [SetUp]
        public void SetUp()
        {
            apiController = new Mock<IApiController>(); 
            apiController.Setup(f => f.Get<List<ResponseQueue>>(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>()))
                         .Returns(returnList);
        }

        [Test]
        public void GetQueries_QueryByNullAndEmptyName_ExceptionThrow()
        {
            //Act
            Queues queues = new Queues(apiController.Object);
            //Assert
            Assert.That(() => queues.GetQueries(It.IsAny<String>()), Throws.Exception);
        }

        [Test]
        public void GetQueries_QueryByName_ReturnListQueueTransactions()
        {
            //Arrange
            returnList.Clear();
            returnList.Add(new ResponseQueue());
            //Act
            Queues queues = new Queues(apiController.Object);
            var result = queues.GetQueries("Closed");
            //Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}
