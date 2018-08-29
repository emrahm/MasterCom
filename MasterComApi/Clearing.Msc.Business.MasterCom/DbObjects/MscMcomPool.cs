using Smartway.Ocean.Framework.Pom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    [SWTable("OC_MSC", "MSC_MCOM_POOL")]
    public partial class MscMcomPool : SWDbObject
    {
        #region Properties
        [SWColumn("GUID", ColumnType.GUID)]
        public long guid { get; set; }

        [SWColumn("STATUS", ColumnType.STATUS)]
        public short status { get; set; }

        [SWColumn("LASTUPDATED", ColumnType.LASTUPDATED)]
        public long lastUpdated { get; set; }

        /// <summary>
        /// CB: Chargeback Create
        /// 
        /// </summary>
        [SWColumn("ACTION_TYPE")]
        public string ActionType { get; set; }

        /// <summary>
        /// system clearing no
        /// </summary>
        [SWColumn("CLEARING_REF_KEY")]
        public long ClearingRefKey { get; set; }

        [SWColumn("PROVISION_REF_KEY")]
        public long ProvisionRefKey { get; set; }

        /// <summary>
        /// S:Start R: Running C: Complete, E: Error.
        /// </summary>
        [SWColumn("PROCESS_STATUS")]
        public string ProcessStatus { get; set; }

        [SWColumn("PROCESS_DESCRIPTION")]
        public string ProcessDescription { get; set; }

        /// <summary>
        /// Chargeback Id, Document Request Id
        /// </summary>
        [SWColumn("MCOM_REF_NO")]
        public string McomRefNo { get; set; }

        #endregion
    }  
}
