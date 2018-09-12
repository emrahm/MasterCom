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
    public class UpdateResponseStatusTests
    {
        Mock<ITransactionRepository> iTransactionRepositoryMock = new Mock<ITransactionRepository>();
        Mock<IChargebacks> iChargebacksMock = new Mock<IChargebacks>();
        Mock<IRetrievals> iRetrievalsMock = new Mock<IRetrievals>();
        Mock<ICaseFiling> iCaseFilingMock = new Mock<ICaseFiling>();
        MscMcomPool mscMcomPool = new MscMcomPool();
        List<MscMcomPool> pendingStatus = null;
        [SetUp]
        public void SetUp()
        { 
            pendingStatus = new List<MscMcomPool>();
            pendingStatus.Add(new MscMcomPool() { ActionType = ApiConstants.PoolActionType.Chargeback, ClaimId = "1", McomRefNo = "2" });
            pendingStatus.Add(new MscMcomPool() { ActionType = ApiConstants.PoolActionType.Chargeback, ClaimId = "2", McomRefNo = "5" });
            pendingStatus.Add(new MscMcomPool() { ActionType = ApiConstants.PoolActionType.CaseFilling, ClaimId = "2", McomRefNo = "5" });
            pendingStatus.Add(new MscMcomPool() { ActionType = ApiConstants.PoolActionType.Retrieval, ClaimId = "1", McomRefNo = "2" });
            pendingStatus.Add(new MscMcomPool() { ActionType = ApiConstants.PoolActionType.Retrieval, ClaimId = "2", McomRefNo = "5" });
 
            List<RetrievalResponse> retrievalResponse = new List<RetrievalResponse>();
            retrievalResponse.Add(new RetrievalResponse() { requestId = "2", status = "COMPLETED" });
            retrievalResponse.Add(new RetrievalResponse() { requestId = "5", status = "PENDING" });

            List<ChargebackStatusResponse> chargebackStatusResponse = new List<ModelData.ChargebackStatusResponse>();
            chargebackStatusResponse.Add(new ChargebackStatusResponse() { chargebackId = "2", status = "COMPLETED" });
            chargebackStatusResponse.Add(new ChargebackStatusResponse() { chargebackId = "5", status = "COMPLETED" });

            List<CaseFilingResponse> caseFilingResponse = new List<CaseFilingResponse>();
            caseFilingResponse.Add(new CaseFilingResponse() { caseId = "5", status = "COMPLETED" });

            iTransactionRepositoryMock.Setup(f => f.GetPoolPendingStatu()).Returns(pendingStatus);
            iChargebacksMock.Setup(f => f.ChargebacksStatus(It.IsAny<long>(), It.IsAny<List<ChargebackRequest>>())).Returns(chargebackStatusResponse);
            iRetrievalsMock.Setup(f => f.RetrievalFullfilmentStatus(It.IsAny<long>(), It.IsAny<List<RetrievalRequest>>())).Returns(retrievalResponse);
            iCaseFilingMock.Setup(f => f.CaseStatus(It.IsAny<long>(), It.IsAny<List<CaseIdRequestResponse>>())).Returns(caseFilingResponse);

        }

        [Test]
        public void Create_UpdateStatu_UpdateReponseStatus()
        {
         
            //act
            UpdateReponseStatus updateReponseStatus = new UpdateReponseStatus(iTransactionRepositoryMock.Object,
                                                                              iChargebacksMock.Object,
                                                                              iRetrievalsMock.Object,
                                                                              iCaseFilingMock.Object);
            updateReponseStatus.Create(mscMcomPool);
            //assert 
        }
         
    }
}
