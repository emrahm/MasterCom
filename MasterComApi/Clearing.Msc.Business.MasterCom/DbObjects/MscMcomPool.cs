using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    public class MscMcomPool
    { 
        public Int64 Guid { get; set; }
        public Int16 Status { get; set; }
        public Int64 LastUpdated { get; set; }
        public String ActionType { get; set; }
        public Int64 ClearingRefKey { get; set; }
        public Int64 ProvisionRefKey { get; set; }
        public String ProcessStatus { get; set; }
        public String McomRefNo { get; set; }
    }
}
