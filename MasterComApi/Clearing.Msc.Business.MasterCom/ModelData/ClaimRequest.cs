using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{ 
    public class ClaimRequest
    {
        public string disputedAmount { get; set; }
        public string disputedCurrency { get; set; }
        public string claimType { get; set; }
        public string clearingTransactionId { get; set; }
    }
}
