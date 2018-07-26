using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    /// <summary>
    /// The queue to be queried for a list of claims
    /// </summary>
    public class ResponseQueue
    {
        /// <summary>
        ///  Acquirer Inst Id
        /// </summary>
        public string acquirerId { get; set; }
        /// <summary>
        ///  Acquirer Reference Number
        /// </summary>		
        public string acquirerRefNum { get; set; }
        /// <summary>
        ///  Card Number for which the Claim is opened
        /// </summary>
        public string primaryAccountNum { get; set; }
        /// <summary>
        ///  Claim Id
        /// </summary>
        public string claimId { get; set; }
        /// <summary>
        ///  The clearing due date of the claim
        /// </summary>
        public string clearingDueDate { get; set; }
        /// <summary>
        ///  Clearing Network
        /// </summary>
        public string clearingNetwork { get; set; }
        /// <summary>
        ///  This is the date of the Claim creation
        /// </summary>
        public string createDate { get; set; }
        /// <summary>
        ///  The due date of the claim
        /// </summary>
        public string dueDate { get; set; }
        /// <summary>
        ///  Transaction Id
        /// </summary>
        public string transactionId { get; set; }
        /// <summary>
        ///  True if the claim value is accurate
        /// </summary>
        public string isAccurate { get; set; }
        /// <summary>
        ///  True if the claim is acquirer
        /// </summary>
        public string isAcquirer { get; set; }
        /// <summary>
        ///  True if the claim is issuer
        /// </summary>
        public string isIssuer { get; set; }
        /// <summary>
        ///  True if the claim is open
        /// </summary>
        public string isOpen { get; set; }
        /// <summary>
        ///  The issuer institution identifier
        /// </summary>
        public string issuerId { get; set; }
        /// <summary>
        ///  User who signed this event
        /// </summary>
        public string lastModifiedBy { get; set; }
        /// <summary>
        ///  The date of the last claim modification
        /// </summary>
        public string lastModifiedDate { get; set; }
        /// <summary>
        ///  Returns the related merchant identifier
        /// </summary>
        public string merchantId { get; set; }
        /// <summary>
        ///  The progress state of the claim
        /// </summary>
        public string progressState { get; set; }
        /// <summary>
        ///  Claim Type
        /// </summary>
        public string claimType { get; set; }
        /// <summary>
        ///  The value of the claim
        /// </summary>
        public string claimValue { get; set; }
    }
}
