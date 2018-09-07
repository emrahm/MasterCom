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
        /// I: Issuer
        /// A: ACquirer
        /// D: Document
        /// F: Fee
        /// R: Fraud
        /// </summary>
        [SWColumn("TRANSACTION_TYPE")]
        public string TransactionType { get; set; }
        /// <summary>
        /// system clearing no
        /// </summary>
        [SWColumn("CLEARING_REF_KEY")]
        public long ClearingRefKey { get; set; }
        /// <summary>
        /// Prov guid, txn guid
        /// </summary>
        [SWColumn("PROVISION_REF_KEY")]
        public long ProvisionRefKey { get; set; }
        /// <summary>
        /// S:Start R: Running C: Complete, E: Error.
        /// </summary>
        [SWColumn("PROCESS_STATUS")]
        public string ProcessStatus { get; set; }
        /// <summary>
        /// Acıklama hata mesajı
        /// </summary>
        [SWColumn("PROCESS_DESCRIPTION")]
        public string ProcessDescription { get; set; }
        /// <summary>
        /// Chargeback Id, Document Request Id
        /// </summary>
        [SWColumn("CLAIM_ID")]
        public string ClaimId { get; set; }
        /// <summary>
        /// Chargeback Id, Document Request Id
        /// </summary>
        [SWColumn("MCOM_REF_NO")]
        public string McomRefNo { get; set; }
        /// <summary>
        /// Chargeback statu update yapılacak.
        /// </summary>
        [SWColumn("RESPONSE_STATUS")]
        public string ResponseStatus { get; set; }
        /// <summary>
        /// Statu update yapıldıgındaki zaman.
        /// Status of chargeback image. Valid responses are COMPLETED, FAILED, PENDING, UNAVAILABLE
        /// </summary>
        [SWColumn("RESPONSE_STATUS_DATETIME")]
        public DateTime ResponseStatusDatetime { get; set; }
        #endregion
    }
}
