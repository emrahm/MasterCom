using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class CaseFilingDetails
    {
        public string claimId { get; set; }
        public string claimType { get; set; }
        public string caseId { get; set; }
        public string caseType { get; set; }
        public List<string> chargebackRefNum { get; set; }
        public string currencyCode { get; set; }
        public object customerFilingNumber { get; set; }
        public string disputeAmount { get; set; }
        public string dueDate { get; set; }
        public string filingAgaintstIca { get; set; }
        public string filingAs { get; set; }
        public string filingIca { get; set; }
        public string merchantName { get; set; }
        public string primaryAccountNum { get; set; }
        public string violationCode { get; set; }
        public string violationDate { get; set; }
        public string rulingDate { get; set; }
        public string rulingStatus { get; set; }
    }
}
