using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class TransactionSearchResponse
    {
        public string authorizationSummaryCount { get; set; }
        public string message { get; set; }
        public List<AuthorizationSummary> authorizationSummary { get; set; }
    }
}
