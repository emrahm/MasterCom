using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    /// <summary>
    /// Transaction sorgulama yapılacak bilgiler.
    /// </summary>
    public class MscTransactionData
    {
        public Int64 ClrNo { get; set; }
        public String CardNo { get; set; }
        public String Arn { get; set; }
        public DateTime TxnDate { get; set; }
        public Int64 ProvGuid { get; set; } 
    }
}
