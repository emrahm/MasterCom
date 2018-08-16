using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class RetrievalDetails
    {
        public string acquirerRefNum { get; set; }
        public string acquirerResponseCd { get; set; }
        public string acquirerMemo { get; set; }
        public string acquirerResponseDt { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string claimId { get; set; }
        public string issuerResponseCd { get; set; }
        public string issuerRejectRsnCd { get; set; }
        public string issuerMemo { get; set; }
        public string issuerResponseDt { get; set; }
        public string imageReviewDecision { get; set; }
        public string imageReviewDt { get; set; }
        public string primaryAcctNum { get; set; }
        public string requestId { get; set; }
        public string retrievalRequestReason { get; set; }
        public string docNeeded { get; set; }
        public string createDate { get; set; }
    }
}
