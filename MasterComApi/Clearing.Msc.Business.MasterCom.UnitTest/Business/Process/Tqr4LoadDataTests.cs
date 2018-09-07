using Clearing.Msc.Business.MasterCom.Business;
using Clearing.Msc.Business.MasterCom.Business.Process;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Tqr4;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Business.Process
{
    [TestFixture]
    public class Tqr4LoadDataTests
    {
        Mock<ITqr4FileParser> iTqr4FileParserMock = new Mock<ITqr4FileParser>();
        Mock<ITransactionRepository> iTransactionRepositoryMock = new Mock<ITransactionRepository>();
        Tqr4FileFieldData sampleData = new Tqr4FileFieldData();

        [SetUp]
        public void SetUp()
        {
            iTqr4FileParserMock.Setup(f => f.GetParseData()).Returns(new List<Tqr4FileFieldData>
            {
                sampleData
            });
        }

        [Test]
        public void LoadData_InsertData_NoException()
        { 
            //arrange
            sampleData.F004 = "000000001212";
            sampleData.F005 = "000000001212";
            sampleData.F006 = "000000001212";
            sampleData.F012 = "180421120000";
            //act
            Tqr4LoadData Tqr4LoadData = new Tqr4LoadData(iTqr4FileParserMock.Object,
                                                         iTransactionRepositoryMock.Object);
            Tqr4LoadData.LoadData();
            //assert

            iTqr4FileParserMock.Verify(f => f.GetParseData());
            iTransactionRepositoryMock.Verify(f => f.InsertTqr4Data(It.IsAny<List<MscMcomTqr4>>()));
        }
    }
}
