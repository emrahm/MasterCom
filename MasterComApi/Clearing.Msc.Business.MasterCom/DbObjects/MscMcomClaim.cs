using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    public class MscMcomClaim
    {
        public Int64 Guid { get; set; }
        public Int16 Status { get; set; }
        public Int64 LastUpdated { get; set; }
        public String ClearingTransactionId { get; set; }
        public Int64 ClrKey { get; set; }
        public Int64 AuthKey { get; set; }
        public String ClaimId { get; set; }
        public String ClaimStatu { get; set; }
    }
}
