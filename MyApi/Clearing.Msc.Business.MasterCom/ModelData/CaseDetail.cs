using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class CaseDetail
    {
        public string caseType { get; set; }
        public List<string> chargebackRefNum { get; set; }
        public string customerFilingNumber { get; set; }
        public string violationCode { get; set; }
        public string violationDate { get; set; }
        public string disputeAmount { get; set; }
        public string currencyCode { get; set; }
        public FileAttachment fileAttachment { get; set; }
        public string filedAgainstIca { get; set; }
        public string filingAs { get; set; }
        public string filingIca { get; set; }
        public string memo { get; set; }
    }
}
