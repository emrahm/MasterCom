using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class ClearingSummary
    {
        public string primaryAccountNumber { get; set; }
        public string transactionAmountLocal { get; set; }
        public string dateAndTimeLocal { get; set; }
        public string cardDataInputCapability { get; set; }
        public string cardholderAuthenticationCapability { get; set; }
        public string cardPresent { get; set; }
        public string acquirerReferenceNumber { get; set; }
        public string cardAcceptorName { get; set; }
        public string currencyCode { get; set; }
        public string transactionId { get; set; }
    }
}
