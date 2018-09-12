using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clearing.Msc.Business.MasterCom.Business.Process;
using Moq;
using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.Utility;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Business.Process
{
    [TestFixture]
    public class ProcessQueueTests
    {
        Mock<IOperationFactory> iOperationFactoryMock = new Mock<IOperationFactory>();
        Mock<IOperation> iOperaionMock = new Mock<IOperation>();

        [Test]
        public void Start_QueueAction_RunProcedure()
        {
            //arrange
            iOperationFactoryMock.Setup(f => f.GetOperation(ApiConstants.PoolActionType.Queues)).Returns(iOperaionMock.Object);
            //act
            ProcessQueue processQueue = new ProcessQueue(iOperationFactoryMock.Object);
            processQueue.Start();
            //assert

        }

    }
}
