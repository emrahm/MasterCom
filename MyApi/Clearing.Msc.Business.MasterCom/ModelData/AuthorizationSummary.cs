using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class AuthorizationSummary
    {
        public string originalMessageTypeIdentifier { get; set; }
        public string banknetDate { get; set; }
        public string transactionAmountUsd { get; set; }
        public string primaryAccountNumber { get; set; }
        public string processingCode { get; set; }
        public string transactionAmountLocal { get; set; }
        public string authorizationDateAndTime { get; set; }
        public string track2 { get; set; }
        public string authenticationId { get; set; }
        public string cardAcceptorName { get; set; }
        public string cardAcceptorCity { get; set; }
        public string cardAcceptorState { get; set; }
        public string track1 { get; set; }
        public string currencyCode { get; set; }
        public string chipPresent { get; set; }
        public string transactionId { get; set; }
        public List<ClearingSummary> clearingSummary { get; set; }
    }
}
