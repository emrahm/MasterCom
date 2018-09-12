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
    public class ProcessResponseStatusTests
    {
        Mock<IOperationFactory> iOperationFactoryMock = new Mock<IOperationFactory>();
        Mock<IOperation> iOperaionMock = new Mock<IOperation>();

        [Test]
        public void Start_ProcessResponseStatus_RunProcedure()
        {
            //arrange
            iOperationFactoryMock.Setup(f => f.GetOperation(ApiConstants.PoolActionType.ResponseStatusUpdate)).Returns(iOperaionMock.Object);
            //act
            ProcessResponseStatus processQueue = new ProcessResponseStatus(iOperationFactoryMock.Object);
            processQueue.Start();
            //assert 
        }

    }
}
