using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class RetrievalResponseFulfillmentRequest
    {
        /// <summary>
        /// Issuer Response Code. The following values are valid - APPROVE, REJECT_DOCUMENTATION_NOT_AS_REQUIRED, REJECT_ILLEGIBLE_OR_MISSING
        /// </summary>
        public string issuerResponseCd { get; set; }
        /// <summary>
        /// memo
        /// </summary>
        public string memo { get; set; }
        /// <summary>
        /// Reject Reason Code. The following values are valid : A - TRANSACTION AMOUNT MISSING/ILLEGIBLE, M - MERCHANT NAME MISSING/ILLEGIBLE, P - PRIMARY ACCOUNT NUMBER MISSING/ILLEGIBLE, D - TRANSACTION DATE MISSING/ILLEGIBLE, O - OTHER (it can also be used for NOT A SUBSTITUTE DRAFT
        /// </summary>
        public string rejectReasonCd { get; set; }
    }
}
