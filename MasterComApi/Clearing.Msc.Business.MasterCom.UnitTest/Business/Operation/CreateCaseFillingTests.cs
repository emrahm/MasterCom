using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clearing.Msc.Business.MasterCom.Business.Operation;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Model;
using Moq;
using Clearing.Msc.Business.MasterCom.DbObjects;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Business.Operation
{
    [TestFixture]
    public class CreateCaseFillingTests
    {
        Mock<ITransactionRepository> iTransactionRepositoryMock = new Mock<ITransactionRepository>();
        Mock<ICaseFiling> iCaseFilingMock = new Mock<ICaseFiling>();

        [Test]
        public void Create_CreateCase_CaseFilling()
        {
            //arrange
            MscMcomPool mscMcomPool = new MscMcomPool();
            //act
            CreateCaseFilling createCaseFilling = new CreateCaseFilling(iTransactionRepositoryMock.Object, iCaseFilingMock.Object);
            createCaseFilling.Create(mscMcomPool);
            //assert

        }
    }
}
