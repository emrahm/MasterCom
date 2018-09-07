using System;
using System.Reflection;
using System.Xml.Serialization;
using Smartway.Ocean.Framework.Pom;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    [SWTable("OC_CLR", "CLR_DOCUMENT_ATTACHMENT")]
    public partial class ClrDocumentAttachment : SWDbObject
    {
        #region "Properties"
        [SWColumnAttribute("GUID", ColumnType.GUID)]
        public Int64 Guid;

        [SWColumnAttribute("STATUS", ColumnType.STATUS)]
        public Int16 Status;

        [SWColumnAttribute("LASTUPDATED", ColumnType.LASTUPDATED)]
        public Int64 LastUpdated;

        [SWColumnAttribute("FOLDER_TYPE")]
        public String FolderType;

        [SWColumnAttribute("DOCUMENT_INFO_GUID")]
        public Int64 DocInfoGuid;

        [SWColumnAttribute("FILE_EXTENTION")]
        public String FileExtention;

        [SWColumnAttribute("FILE_NAME")]
        public String FileName;

        [SWColumnAttribute("IS_PRINTED")]
        public String IsPrinted;

        [SWColumnAttribute("MBR_ID", ColumnType.MBR_ID)]
        public Int16 MbrId;

        [SWColumnAttribute("ATTACHMENT")]
        public byte[] Attachment;
        #endregion

    }
}
