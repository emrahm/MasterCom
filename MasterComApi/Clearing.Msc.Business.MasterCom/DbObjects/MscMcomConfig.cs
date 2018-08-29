using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Utility;
using Smartway.Ocean.Framework.Pom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    [SWTable("OC_MSC", "MSC_MCOM_CONFIG")]
    public partial class MscMcomConfig : SWDbObject
    {
        #region Properties
        [SWColumn("GUID", ColumnType.GUID)]
        public long guid { get; set; }

        [SWColumn("STATUS", ColumnType.STATUS)]
        public short status { get; set; }

        [SWColumn("LASTUPDATED", ColumnType.LASTUPDATED)]
        public long lastUpdated { get; set; }

        [SWColumn("CONSUMER_KEY")]
        public string ConsumerKey { get; set; }

        [SWColumn("KEY_PASSWORD")]
        public string KeyPassword { get; set; }

        [SWColumn("CERT_PATH")]
        public string CertPath { get; set; }

        [SWColumn("BASE_URL")]
        public string BaseUrl { get; set; }

        [SWColumn("USER_AGENT_VERSION")]
        public string UserAgentVersion { get; set; }

        [SWColumn("URL_VERSION_NUMBER")]
        public string UrlVersionNumber { get; set; }

        [SWColumn("ENVIRONMENT")]
        public string Environment { get; set; }

        [SWColumn("INSERT_USER", ColumnType.INSERT_USER)]
        public string InsertUser { get; set; }

        [SWColumn("INSERT_DATE_TIME", ColumnType.INSERT_DATE_TIME)]
        public DateTime InsertDateTime { get; set; }

        [SWColumn("UPDATE_USER", ColumnType.UPDATE_USER)]
        public string UpdateUser { get; set; }

        [SWColumn("UPDATE_DATE_TIME", ColumnType.UPDATE_DATE_TIME)]
        public DateTime UpdateDateTime { get; set; }

        #endregion
    }

}
