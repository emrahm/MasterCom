using Smartway.Ocean.Framework.Pom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    [SWTable("OC_MSC", "MSC_MCOM_CLAIM")]
    public partial class MscMcomClaim : SWDbObject
    {
        #region Properties
        [SWColumn("GUID", ColumnType.GUID)]
        public long guid { get; set; }

        [SWColumn("STATUS", ColumnType.STATUS)]
        public short status { get; set; }

        [SWColumn("LASTUPDATED", ColumnType.LASTUPDATED)]
        public long lastUpdated { get; set; }

        [SWColumn("CLEARING_TRANSACTION_ID")]
        public string ClearingTransactionId { get; set; }

        [SWColumn("CLR_KEY")]
        public long ClrKey { get; set; }

        [SWColumn("AUTH_KEY")]
        public long AuthKey { get; set; }

        [SWColumn("CLAIM_ID", ColumnType.KEY)]
        public string ClaimId { get; set; }

        [SWColumn("CLAIM_STATU")]
        public string ClaimStatu { get; set; }

        #endregion
    }
}
