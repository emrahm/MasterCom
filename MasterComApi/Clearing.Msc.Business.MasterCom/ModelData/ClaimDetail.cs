using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class ClaimDetail
    {
        public string acquirerId { get; set; }
        public string acquirerRefNum { get; set; }
        public string primaryAccountNum { get; set; }
        public string claimId { get; set; }
        public string claimType { get; set; }
        public string claimValue { get; set; }
        public object standardClaims { get; set; }
        public string clearingDueDate { get; set; }
        public string clearingNetwork { get; set; }
        public string createDate { get; set; }
        public string dueDate { get; set; }
        public string transactionId { get; set; }
        public string isAccurate { get; set; }
        public string isAcquirer { get; set; }
        public string isIssuer { get; set; }
        public string isOpen { get; set; }
        public string issuerId { get; set; }
        public string lastModifiedBy { get; set; }
        public string lastModifiedDate { get; set; }
        public string merchantId { get; set; }
        public string queueName { get; set; }
        public RetrievalDetails retrievalDetails { get; set; }
        public List<ChargebackDetail> chargebackDetails { get; set; }
        public List<FeeDetail> feeDetails { get; set; }
        public CaseFilingDetails caseFilingDetails { get; set; }
    }
}
