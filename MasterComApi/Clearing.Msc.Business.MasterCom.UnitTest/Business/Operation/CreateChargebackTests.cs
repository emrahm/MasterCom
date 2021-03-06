﻿using Clearing.Msc.Business.MasterCom.Business;
using Clearing.Msc.Business.MasterCom.Business.Operation;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Operation;
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
    [TestFixture]
    public class CreateChargebackTests
    {
        CreateIssuerChargeback createChargeback = null;
        Mock<ITransactionRepository> transactionData = new Mock<ITransactionRepository>();
        Mock<IChargebacks> chargebacks = new Mock<IChargebacks>();
        Mock<IClaims> claims = new Mock<IClaims>();
        Mock<ITransactions> transactions = new Mock<ITransactions>();
        MscMcomPool mscMcomPool = null;
        String claimId = "123";
        String clearingTransactionId = "12345";
        String chargebackId = "234";
        [SetUp]
        public void SetUp()
        {
            createChargeback = new CreateIssuerChargeback(transactionData.Object,
                                                    transactions.Object,
                                                    claims.Object,
                                                    chargebacks.Object);

            mscMcomPool = new MscMcomPool();
            mscMcomPool.ClearingRefKey = 1;
            mscMcomPool.ProvisionRefKey = 2;
            mscMcomPool.McomRefNo = null;

            var mscTransactionData = new MscTransaction
            {
                F002 = "1234567890123456"
            };

            transactionData.Setup(f => f.GetIssuerData(mscMcomPool)).Returns(mscTransactionData);


        }

        [Test]
        public void Create_TakenTransactionAndClaimBefore_GetChargebackIdInMcomRefNo()
        {
            //arrange  9
            chargebacks.Setup(f => f.Create(It.IsAny<long>(), claimId, It.IsAny<ChargebackFillRequest>())).Returns(chargebackId);
            transactionData.Setup(f => f.GetTransactionId(mscMcomPool.ProvisionRefKey)).Returns(new MscMcomTransaction
            {
                ClearingTransactionId = clearingTransactionId,
                ClaimId = claimId
            });

            transactionData.Setup(f => f.GetClaim(claimId)).Returns(new MscMcomClaim
            {
                ClaimId = claimId
            });

            transactionData.Setup(f => f.GetDocumentInfo(It.IsAny<long>(), ApiConstants.PoolActionType.ChargebackDocument)).Returns(new ClrDocumentInfo());

            //act
            createChargeback.Create(mscMcomPool);
            //assert
            Assert.That(mscMcomPool.McomRefNo, Is.Not.Null);
            Assert.That(mscMcomPool.McomRefNo, Is.EqualTo(chargebackId));
            transactionData.Verify(f => f.GetIssuerData(mscMcomPool));
        }

        [Test]
        public void Create_NotTakenClaim_GetChargebackIdInMcomRefNo()
        {
            //arrange  9
            var mscMcomTransactionId = new MscMcomTransaction
            {
                ClearingTransactionId = clearingTransactionId
            };

            chargebacks.Setup(f => f.Create(It.IsAny<long>(), claimId, It.IsAny<ChargebackFillRequest>())).Returns(chargebackId);
            transactionData.Setup(f => f.GetTransactionId(mscMcomPool.ProvisionRefKey)).Returns(mscMcomTransactionId);
            transactionData.Setup(f => f.GetClaim(mscMcomTransactionId.ClaimId)).Returns((MscMcomClaim)null);
            claims.Setup(f => f.CreateClaim(It.IsAny<long>(), It.IsAny<ClaimRequest>())).Returns(claimId);
            //act
            createChargeback.Create(mscMcomPool);
            //assert
            Assert.That(mscMcomPool.McomRefNo, Is.Not.Null);
            Assert.That(mscMcomPool.McomRefNo, Is.EqualTo(chargebackId));
            Assert.That(mscMcomTransactionId.ClaimId, Is.EqualTo(claimId));
            transactionData.Verify(f => f.GetIssuerData(mscMcomPool));
            transactionData.Verify(f => f.GetClaim(mscMcomTransactionId.ClaimId), Times.Never(), "MscMcomTransactionId claim id null ise GetClaim fonksiyonu cagırılmayacak.");
            transactionData.Verify(f => f.CreateClaim(It.IsAny<MscMcomClaim>()));
            transactionData.Verify(f => f.UpdateClaimId(mscMcomTransactionId));
        }

        [Test]
        public void Create_NoTransactionNoClaimSavedBefore_GetChargebackIdInMcomRefNo()
        {
            //arrange  9  
            var mscTransactionData = new MscTransaction
            {
                F002 = "1234567890123456",
                F012_s1 = "180904"
            };
            var transactionSearchResponse = new TransactionSearchResponse
            {
                authorizationSummaryCount = "1",
                authorizationSummary = new List<AuthorizationSummary> 
                {
                    new AuthorizationSummary
                    {
                         clearingSummary = new List<ClearingSummary>
                         {
                            new ClearingSummary 
                            {
                                 transactionId = "123"
                            }
                         }
                    }
                }
            };
            transactionData.Setup(f => f.GetTransactionId(mscMcomPool.ProvisionRefKey)).Returns((MscMcomTransaction)null);
            transactionData.Setup(f => f.GetIssuerData(mscMcomPool)).Returns(mscTransactionData);
            transactionData.Setup(f => f.GetClaim(It.IsAny<String>())).Returns((MscMcomClaim)null);
            transactions.Setup(f => f.Search(It.IsAny<long>(), It.IsAny<TransactionSearchRequest>())).Returns(transactionSearchResponse);
            chargebacks.Setup(f => f.Create(It.IsAny<long>(), claimId, It.IsAny<ChargebackFillRequest>())).Returns(chargebackId);
            claims.Setup(f => f.CreateClaim(It.IsAny<long>(), It.IsAny<ClaimRequest>())).Returns(claimId);
            //act
            createChargeback.Create(mscMcomPool);
            //assert
            Assert.That(mscMcomPool.McomRefNo, Is.Not.Null);
            Assert.That(mscMcomPool.McomRefNo, Is.EqualTo(chargebackId));

            transactionData.Verify(f => f.GetTransactionId(It.IsAny<long>()));
            transactionData.Verify(f => f.GetIssuerData(mscMcomPool));
            transactionData.Verify(f => f.CreateTransactionId(It.IsAny<MscMcomTransaction>()));
        }
    }
}
