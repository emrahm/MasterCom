using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class ChargebackDetail
    {
        public string currency { get; set; }
        public string documentIndicator { get; set; }
        public string messageText { get; set; }
        public string amount { get; set; }
        public string reasonCode { get; set; }
        public bool isPartialChargeback { get; set; }
        public string chargebackType { get; set; }
        public string chargebackId { get; set; }
        public string claimId { get; set; }
        public bool reversed { get; set; }
        public bool reversal { get; set; }
        public string createDate { get; set; }
    }
}
