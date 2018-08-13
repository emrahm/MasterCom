using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    public class MscMcomTransactionId
    {
        public Int64 Guid { get; set; }
        public Int16 Status { get; set; }
        public Int64 LastUpdated { get; set; }
        public Int64 ClrRefKey { get; set; }
        public Int64 AuthRefNo { get; set; }
        public String ClearingTransactionId { get; set; }
        public String AuthenticationTransactionId { get; set; }
    }
}
