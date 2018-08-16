using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{ 
    public class FraudRequest
    {
        public string deviceType { get; set; }
        public string acctStatus { get; set; }
        public string reportDate { get; set; }
        public string fraudType { get; set; }
        public string subType { get; set; }
        public string cvcInvalidIndicator { get; set; }
        public string chgbkIndicator { get; set; }
    }
}
