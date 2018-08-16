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
        /// <summary>
        /// CB: Chargeback Create
        /// 
        /// </summary>
        public String ActionType { get; set; }
        /// <summary>
        /// system clearing no
        /// </summary>
        public Int64 ClearingRefKey { get; set; }
        /// <summary>
        /// Prov Guid
        /// </summary>
        public Int64 ProvisionRefKey { get; set; }
        /// <summary>
        /// S:Start R: Running C: Complete, E: Error.
        /// </summary>
        public String ProcessStatus { get; set; }
        /// <summary>
        /// ProcessDescription 
        /// </summary>
        public String ProcessDescription { get; set; }
        /// <summary>
        /// Chargeback Id, Document Request Id
        /// </summary>
        public String McomRefNo { get; set; }
    }
}
