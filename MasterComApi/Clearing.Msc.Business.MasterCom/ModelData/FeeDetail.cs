using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class FeeDetail
    {
        public string cardAcceptorIdCode { get; set; }
        public string cardNumber { get; set; }
        public string countryCode { get; set; }
        public string currency { get; set; }
        public string feeDate { get; set; }
        public string destinationMember { get; set; }
        public string feeAmount { get; set; }
        public string creditSender { get; set; }
        public string creditReceiver { get; set; }
        public string message { get; set; }
        public string reason { get; set; }
        public string feeId { get; set; }
    }
}
