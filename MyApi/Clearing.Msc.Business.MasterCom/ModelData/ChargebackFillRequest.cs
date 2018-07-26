using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{ 
    public class ChargebackFillRequest
    {
        public ChargebackFillRequest()
        {
            fileAttachment = new FileAttachment();
        }
        public string currency { get; set; }
        public string documentIndicator { get; set; }
        public string messageText { get; set; }
        public string amount { get; set; }
        public FileAttachment fileAttachment { get; set; }
        public string reasonCode { get; set; }
        public string chargebackType { get; set; }
        public string memo { get; set; }
    }
}
