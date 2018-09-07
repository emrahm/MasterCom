using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartway.Ocean.Framework.Pom;

namespace Clearing.Msc.Business.MasterCom.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public FileAttachment GetAttachment(ClrDocumentInfo clrDocumentInfo)
        {
            FileAttachment fileAttachment = new FileAttachment();
            fileAttachment.filename = clrDocumentInfo.Filename;
            foreach (var item in new ClrDocumentAttachment().find<ClrDocumentAttachment>(new SWDbObjectQuery("DocInfoGuid", clrDocumentInfo.Guid)))
            {
                fileAttachment.file = Convert.ToBase64String(item.Attachment, 0, item.Attachment.Length);
            }
            return fileAttachment;
        }

        public ClrDocumentInfo GetDocumentInfo(long pGuid, String actionType)
        {
            foreach (var item in new ClrDocumentInfo().find<ClrDocumentInfo>(new SWDbObjectQuery("Pguid", pGuid)))
            {
                if (item.Type == actionType)
                    return item;
            }
            return null;
        }

        public MscMcomTransaction GetTransactionId(long provGuid)
        {
            foreach (var item in new MscMcomTransaction().find<MscMcomTransaction>(new SWDbObjectQuery("AuthRefKey", provGuid)))
            {
                return item;
            }
            return null;
        }

        public void CreateTransactionId(MscMcomTransaction mscMcomTransactionId)
        {
            mscMcomTransactionId.Create();
        }

        public MscTransaction GetIssuerData(MscMcomPool mscMcomPool)
        {
            MscIssuer mscIssuer = new MscIssuer();
            if (mscIssuer.findByKey(mscMcomPool.ClearingRefKey))
                return mscIssuer;
            return null;
        }

        public MscTransaction GetAcquirerData(MscMcomPool mscMcomPool)
        {
            MscAcquirer mscAcquirer = new MscAcquirer();
            if (mscAcquirer.findByKey(mscMcomPool.ClearingRefKey))
                return mscAcquirer;
            return null;
        }


        public MscMcomClaim GetClaim(string claimId)
        {
            MscMcomClaim mscMcomClaim = new MscMcomClaim();
            if (mscMcomClaim.findByKey(claimId))
                return mscMcomClaim;
            return null;
        }

        public MscMcomClaim GetClaim(Int64 provGuid)
        {
            SWDbObjectQuery query = new SWDbObjectQuery();
            query.AddSearchCriteria("AuthKey", provGuid);
            foreach (var item in new MscMcomClaim().find<MscMcomClaim>(query))
            {
                return item;
            }
            return null;
        }

        public void CreateClaim(MscMcomClaim mscMcomClaim)
        {
            mscMcomClaim.Create();
        }

        public void UpdateClaimId(MscMcomTransaction mscMcomTransactionId)
        {
            mscMcomTransactionId.Update();
        }

        public List<MscMcomPool> GetPool()
        {
            SWDbObjectQuery query = new SWDbObjectQuery();
            query.AddSearchCriteria("ProcessStatus", "S");
            return new MscMcomPool().find<MscMcomPool>(query);
        }

        public void UpdatePoolItem(MscMcomPool mscMcomPool)
        {
            mscMcomPool.Update();
        }

        public void InsertTqr4Data(List<MscMcomTqr4> mscMcomTqr4List)
        {
            MscMcomTqr4 mscMcomTqr4 = new MscMcomTqr4();
            mscMcomTqr4.Create<MscMcomTqr4>(mscMcomTqr4List);
        }

        public MscMcomPool GetMscMcomPoolClearingNo(long clearingNo, String actionType)
        {
            SWDbObjectQuery query = new SWDbObjectQuery();
            query.AddSearchCriteria("ClearingRefKey", clearingNo);
            query.AddSearchCriteria("ActionType", actionType);
            foreach (var item in new MscMcomPool().find<MscMcomPool>(query))
            {
                return item;
            }
            return null;
        }

        public MscMcomQueue GetQueueData(MscMcomQueue mscMcomQueueResponse)
        {
            throw new NotImplementedException();
        }

        public void CreateQueueData(List<MscMcomQueue> mscMcomQueueList)
        {
            throw new NotImplementedException();
        }





        public void UpdatePoolData(List<MscMcomPool> updateStatuList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MscMcomPool> GetPoolPendingStatu()
        {
            throw new NotImplementedException();
        }
    }
}
