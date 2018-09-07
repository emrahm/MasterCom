using System;
using System.Reflection;
using System.Xml.Serialization;
using Smartway.Ocean.Framework.Pom;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    [SWTable("OC_CLR", "CLR_DOCUMENT_INFO")]
    public partial class ClrDocumentInfo : SWDbObject
    {
        #region "Properties"
        [SWColumnAttribute("GUID", ColumnType.GUID)]
        public Int64 Guid;

        [SWColumnAttribute("STATUS", ColumnType.STATUS)]
        public Int16 Status;

        [SWColumnAttribute("LASTUPDATED", ColumnType.LASTUPDATED)]
        public Int64 LastUpdated;

        [SWColumnAttribute("PGM_CODE")]
        public String PgmCode;

        [SWColumnAttribute("TYPE")]
        public String Type;

        [SWColumnAttribute("PGUID")]
        public Int64 Pguid;

        [SWColumnAttribute("DOC_STATUS")]
        public String DocStatus;

        [SWColumnAttribute("DOC_DATE")]
        public DateTime DocDate;

        [SWColumnAttribute("FILENAME")]
        public String Filename;

        [SWColumnAttribute("DESCRIPTION")]
        public String Description;

        [SWColumnAttribute("INSERT_DATE")]
        public DateTime InsertDate;

        [SWColumnAttribute("INSERT_TIME")]
        public Int32 InsertTime;

        [SWColumnAttribute("INSERT_USER", ColumnType.INSERT_USER)]
        public String InsertUser;

        [SWColumnAttribute("LAST_UPD_DATE")]
        public DateTime LastUpdDate;

        [SWColumnAttribute("LAST_UPD_TIME")]
        public Int32 LastUpdTime;

        [SWColumnAttribute("LAST_UPD_USER", ColumnType.UPDATE_USER)]
        public String LastUpdUser;

        [SWColumnAttribute("IS_PRINTED")]
        public String IsPrinted;

        [SWColumnAttribute("MBR_ID", ColumnType.MBR_ID)]
        public Int16 MbrId;
        #endregion
    }
}
