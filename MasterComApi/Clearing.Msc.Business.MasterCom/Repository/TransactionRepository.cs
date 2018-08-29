using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public MscTransactionData GetPresentmentData(MscMcomPool mscMcomPool)
        {
            throw new NotImplementedException();
        }

        public ChargebackFillRequest GetChargebackData(long clrNo)
        {
            throw new NotImplementedException();
        }

        public MscMcomTransaction GetTransactionId(long provGuid)
        {
            throw new NotImplementedException();
        }

        public bool CreateTransactionId(MscMcomTransaction mscMcomTransactionId)
        {
            throw new NotImplementedException();
        }

        public MscMcomClaim CreateClaim(MscMcomPool mscMcomPool)
        {
            throw new NotImplementedException();
        }

        public MscMcomClaim GetClaim(string claimId)
        {
            throw new NotImplementedException();
        }

        public void CreateClaim(MscMcomClaim mscMcomClaim)
        {
            throw new NotImplementedException();
        }

        public void UpdateClaimId(MscMcomTransaction mscMcomTransactionId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<MscMcomPool> GetPool()
        {
            throw new NotImplementedException();
        }

        public void UpdatePoolItem(MscMcomPool item)
        {
            throw new NotImplementedException();
        }


        public void InsertTqr4Data(List<MscMcomTqr4> mscMcomTqr4List)
        {
            throw new NotImplementedException();
        }
    }
}
