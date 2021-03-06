﻿using Smartway.Ocean.Framework.Pom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    [SWTable("OC_MSC", "MSC_MCOM_REQUEST")]
    public partial class MscMcomRequest : SWDbObject
    {
        #region Properties
        [SWColumn("GUID", ColumnType.GUID)]
        public long guid { get; set; }

        [SWColumn("STATUS", ColumnType.STATUS)]
        public short status { get; set; }

        [SWColumn("LASTUPDATED", ColumnType.LASTUPDATED)]
        public long lastUpdated { get; set; }

        [SWColumn("REF_KEY")]
        public long RefKey { get; set; }

        [SWColumn("URL")]
        public string Url { get; set; }

        [SWColumn("REQUEST")]
        public string Request { get; set; }

        [SWColumn("RESPONSE")]
        public string Response { get; set; }

        [SWColumn("HTTP_STATUS")]
        public int HttpStatus { get; set; }

        #endregion
    }

}
