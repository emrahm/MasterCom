using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{ 
    /// <summary>
    /// This resource creates a new claim
    /// </summary>
    public class ClaimRequest
    {
        /// <summary>
        /// Amount disputed in the claim
        /// </summary>
        public string disputedAmount { get; set; }
        /// <summary>
        /// Currency of amount disputed in the claim
        /// </summary>
        public string disputedCurrency { get; set; }
        /// <summary>
        /// Type of claim to be created. The following values are valid - Standard
        /// </summary>
        public string claimType { get; set; }
        /// <summary>
        /// The Clearing Transaction Identifier from Clearing Summary Results
        /// </summary>
        public string clearingTransactionId { get; set; }
    }
}
