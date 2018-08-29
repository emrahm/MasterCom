using Smartway.Ocean.Framework.Pom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    [SWTable("OC_MSC", "MSC_MCOM_TRANSACTION")]
    public partial class MscMcomTransaction : SWDbObject
    {
        #region Properties
        [SWColumn("GUID", ColumnType.GUID)]
        public long guid { get; set; }

        [SWColumn("STATUS", ColumnType.STATUS)]
        public short status { get; set; }

        [SWColumn("LASTUPDATED", ColumnType.LASTUPDATED)]
        public long lastUpdated { get; set; }

        [SWColumn("CLR_REF_KEY")]
        public long ClrRefKey { get; set; }

        [SWColumn("AUTH_REF_KEY")]
        public long AuthRefKey { get; set; }

        [SWColumn("CLEARING_TRANSACTION_ID")]
        public string ClearingTransactionId { get; set; }

        [SWColumn("AUTHENTICATION_TRANSACTION_ID")]
        public string AuthenticationTransactionId { get; set; }

        [SWColumn("CLAIM_ID")]
        public string ClaimId { get; set; }

        #endregion
    }

}
