using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clearing.Msc.Business.MasterCom.Business;
using Clearing.Msc.Business.MasterCom.Repository;
using Moq;
using Clearing.Msc.Business.MasterCom.DbObjects;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Business
{
    [TestFixture]
    public class ProcessPoolTests
    {
        Mock<ITransactionRepository> iTransactionRepositoryMock = new Mock<ITransactionRepository>();
        Mock<IOperationFactory> iOperationFactoryMock = new Mock<IOperationFactory>();
        Mock<IOperation> iOperaionMock = new Mock<IOperation>();
        MscMcomPool mscMcomPool = new MscMcomPool();

        [SetUp]
        public void SetUp()
        {
            mscMcomPool.ActionType = "CB";
            iTransactionRepositoryMock.Setup(f => f.GetPool()).Returns(new List<MscMcomPool>() { mscMcomPool });
            iOperationFactoryMock.Setup(f => f.GetOperation(mscMcomPool.ActionType)).Returns(iOperaionMock.Object);
        }


        [Test]
        public void Start_ProcessPool_RunOperationComplete()
        {
            //arrange 
            //act
            ProcessPool processPool = new ProcessPool(iTransactionRepositoryMock.Object, iOperationFactoryMock.Object);
            processPool.Start();
            //assert
            CommonVerifyControl();
            Assert.That(mscMcomPool.ProcessStatus, Is.EqualTo("C"));

        }

        [Test]
        public void Start_ProcessPool_RunOperationException()
        {
            //arrange
            iOperaionMock.Setup(f => f.Create(It.IsAny<MscMcomPool>())).Throws<Exception>();
            //act
            ProcessPool processPool = new ProcessPool(iTransactionRepositoryMock.Object, iOperationFactoryMock.Object);
            processPool.Start();
            //assert
            CommonVerifyControl();
            Assert.That(mscMcomPool.ProcessStatus, Is.EqualTo("E"));

        }

        private void CommonVerifyControl()
        {
            iTransactionRepositoryMock.Verify(f => f.GetPool());
            iTransactionRepositoryMock.Verify(f => f.UpdatePoolItem(mscMcomPool));
            iOperaionMock.Verify(f => f.Create(mscMcomPool));
        }
    }
}
