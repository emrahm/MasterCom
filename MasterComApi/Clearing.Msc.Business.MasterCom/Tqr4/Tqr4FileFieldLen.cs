using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Tqr4
{
    public class Tqr4FileFieldLen
    {
        /// <summary>
        /// File ID 	
        /// </summary>
        public const int P0105 = 25;
        /// <summary>
        /// Message Number	
        /// </summary>
        public const int F071 = 8;
        /// <summary>
        /// Claim ID
        /// </summary>
        public const int ClaimId = 19;
        /// <summary>
        /// Event ID
        /// </summary>
        public const int EventId = 19;
        /// <summary>
        /// Cycle ID
        /// </summary>
        public const int F095 = 10;
        /// <summary>
        /// Acquirer Reference Number
        /// </summary>
        public const int F031 = 23;
        /// <summary>
        /// Mti
        /// </summary>
        public const int Mtid = 4;
        /// <summary>
        /// Pan
        /// </summary>
        public const int F002 = 19;
        /// <summary>
        /// Processing Code
        /// </summary>
        public const int F003 = 6;
        /// <summary>
        /// Function Code
        /// </summary>
        public const int F024 = 3;
        /// <summary>
        /// Message Reason Code
        /// </summary>
        public const int F025 = 4;
        /// <summary>
        /// Amount Transaction
        /// </summary>
        public const int F004 = 12;
        /// <summary>
        /// Amount Reconciliation
        /// </summary>
        public const int F005 = 12;
        /// <summary>
        /// Amount Cardholder Billing	Amount
        /// </summary>
        public const int F006 = 12;
        /// <summary>
        /// Transaction Currency Code
        /// </summary>
        public const int F049 = 3;
        /// <summary>
        /// Reconciliation Currency Code
        /// </summary>
        public const int F050 = 3;
        /// <summary>
        /// Cardholder Billing Currency code
        /// </summary>
        public const int F051 = 3;
        /// <summary>
        /// (n4-n4-n4)Currency code and exponent 
        /// </summary>
        public const int P0148 = 12;
        /// <summary>
        /// Retrieval Reference Number
        /// </summary>
        public const int F037 = 12;
        /// <summary>
        /// Mcc
        /// </summary>
        public const int F026 = 4;
        /// <summary>
        /// Card Acceptor ID
        /// </summary>
        public const int F042 = 15;
        /// <summary>
        /// Card Acceptor Name
        /// </summary>
        public const int F043 = 22;
        /// <summary>
        /// Date & Time of Transaction
        /// </summary>
        public const int F012 = 12;
        /// <summary>
        /// Transaction Originator Institution ID Code
        /// </summary>
        public const int F094 = 11;
        /// <summary>
        /// Transaction Destination Institution ID Code
        /// </summary>
        public const int F093 = 11;
        /// <summary>
        /// Transaction Status                          
        /// </summary>
        public const int Status = 7;
        /// <summary>
        /// Reason for Rejection
        /// </summary>
        public const int RejectReason = 512;
        /// <summary>
        /// Reversal Flag
        /// </summary>
        public const int P0025 = 1;
    }
}
