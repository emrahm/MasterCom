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
using Clearing.Msc.Business.MasterCom.Utility;
using Clearing.Msc.Business.MasterCom.ModelData;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Business.Operation
{
    [TestFixture]
    public class UpdateIssuerChargebackTests
    {
        Mock<ITransactionRepository> iTransactionRepositoryMock = new Mock<ITransactionRepository>();
        Mock<IChargebacks> iChargebacksMock = new Mock<IChargebacks>();
        MscMcomPool mscMcomPool = new MscMcomPool();
        MscTransaction mscTransaction = new MscTransaction();
        ClrDocumentInfo clrDocumentInfo = new ClrDocumentInfo();
        String chargebackId = "132231";

        [SetUp]
        public void SetUp()
        {

            mscTransaction.Guid = 1;
            mscTransaction.ClrNo = 2;
            mscTransaction.ProvGuid = 3;

         
            
            iTransactionRepositoryMock.Setup(f => f.GetIssuerData(It.IsAny<MscMcomPool>()))
                .Returns(mscTransaction);
            iTransactionRepositoryMock.Setup(f => f.GetMscMcomPoolClearingNo(mscTransaction.ClrNo, ApiConstants.PoolActionType.Chargeback))
                .Returns(new MscMcomPool() { McomRefNo = "4" });
            iTransactionRepositoryMock.Setup(f => f.GetClaim(mscTransaction.ProvGuid))
                .Returns(new MscMcomClaim() { ClaimId = "1" });

            iChargebacksMock.Setup(f => f.Update(It.IsAny<long>(), It.IsAny<ChargebackRequest>(), It.IsAny<ChargebackFillRequest>()))
             .Returns(chargebackId);

        }

        [Test]
        public void Create_DocumentUpdate_ChargebackUpdate()
        {
            //arrange
            iTransactionRepositoryMock.Setup(f => f.GetDocumentInfo(mscTransaction.Guid, ApiConstants.PoolActionType.ChargebackDocument))
                .Returns(clrDocumentInfo);
            //act
            UpdateIssuerChargeback updateIssuerChargeback = new UpdateIssuerChargeback(iTransactionRepositoryMock.Object, iChargebacksMock.Object);
            updateIssuerChargeback.Create(mscMcomPool);
            //assert
            Assert.That(mscMcomPool.McomRefNo, Is.EqualTo(chargebackId));
        }

        [Test]
        public void Create_NoDocumentInfoData_ThrowException()
        {
            //arrange
            iTransactionRepositoryMock.Setup(f => f.GetDocumentInfo(mscTransaction.Guid, ApiConstants.PoolActionType.ChargebackDocument))
                .Returns((ClrDocumentInfo)null);
            //act
            UpdateIssuerChargeback updateIssuerChargeback = new UpdateIssuerChargeback(iTransactionRepositoryMock.Object, iChargebacksMock.Object);
            Assert.That(() => updateIssuerChargeback.Create(mscMcomPool), Throws.Exception);
        }
    }
}
