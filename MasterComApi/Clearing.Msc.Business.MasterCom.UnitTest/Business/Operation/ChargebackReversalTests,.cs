using Clearing.Msc.Business.MasterCom.Business;
using Clearing.Msc.Business.MasterCom.Business.Operation;
using Clearing.Msc.Business.MasterCom.DbObjects;
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

namespace Clearing.Msc.Business.MasterCom.UnitTest.Business.Operation
{
    public class ChargebackReversalTests
    {
        CreateIssuerChargebackReversal createChargebackReversal = null;
        Mock<ITransactionRepository> transactionData = new Mock<ITransactionRepository>();
        Mock<IChargebacks> chargebacks = new Mock<IChargebacks>();
        MscMcomPool mscMcomPool = null;
        String claimId = "123";
        String clearingTransactionId = "12345";
        String chargebackId = "234";

        [SetUp]
        public void SetUp()
        {
            createChargebackReversal = new CreateIssuerChargebackReversal(transactionData.Object, chargebacks.Object);

            mscMcomPool = new MscMcomPool();
            mscMcomPool.ClearingRefKey = 1;
            mscMcomPool.ProvisionRefKey = 2;
            mscMcomPool.McomRefNo = null;
        }

        [Test]
        public void Create_ReversalCreate_TakeReversalId()
        {
            //arrange
            var mscTransactionData = new MscTransaction() { PrevClearingNo = 11 };
            var mscMcomClaim = new MscMcomClaim() { ClaimId = claimId };
            var cbRevMscMcomPool = new MscMcomPool();
            transactionData.Setup(f => f.GetIssuerData(mscMcomPool)).Returns(mscTransactionData);
            transactionData.Setup(f => f.GetMscMcomPoolClearingNo(mscTransactionData.PrevClearingNo, ApiConstants.Chargeback)).Returns(cbRevMscMcomPool);
            transactionData.Setup(f => f.GetClaim(mscTransactionData)).Returns(mscMcomClaim);
            chargebacks.Setup(f => f.CreateReversal(It.IsAny<long>(), It.IsAny<ChargebackRequest>())).Returns(chargebackId);
            //act
            createChargebackReversal.Create(mscMcomPool);
            //assert
            Assert.That(mscMcomPool.McomRefNo, Is.Not.Null);
            Assert.That(mscMcomPool.McomRefNo, Is.EqualTo(chargebackId));
        }
    }
}
