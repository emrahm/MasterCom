using Clearing.Msc.Business.MasterCom.Business.Factory;
using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business.Operation
{
    public class CreateCaseFilling : IOperation
    {
        ITransactionRepository _iTransactionData = null;
        ICaseFiling _iClaims = null;


        public CreateCaseFilling(ITransactionRepository iTransactionData,
                                 ICaseFiling iClaims)
        {
            _iTransactionData = iTransactionData;
            _iClaims = iClaims;
        }

        public void Create(MscMcomPool mscMcomPool)
        {
            CaseDetailRequest  caseDetailRequest = new CaseDetailRequest();
            
            _iClaims.CreateCase(mscMcomPool.ClearingRefKey, caseDetailRequest);
        }
    }
}
