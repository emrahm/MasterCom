using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class TransactionSearchRequest
    {
        public string acquirerRefNumber { get; set; }
        public string primaryAccountNum { get; set; }
        public string transAmountFrom { get; set; }
        public string transAmountTo { get; set; }
        public string tranStartDate { get; set; }
        public string tranEndDate { get; set; }
    }
}
