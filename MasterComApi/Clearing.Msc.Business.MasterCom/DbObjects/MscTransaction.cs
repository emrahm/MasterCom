using Smartway.Ocean.Framework.Pom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{ 
    public partial class MscTransaction : SWDbObject
    { 
        [SWColumnAttribute("GUID", ColumnType.GUID)]
        public Int64 Guid { get; set; }

        [SWColumnAttribute("STATUS", ColumnType.STATUS)]
        public Int16 Status { get; set; }

        [SWColumnAttribute("LASTUPDATED", ColumnType.LASTUPDATED)]
        public Int64 LastUpdated { get; set; }

        [SWColumnAttribute("CLR_NO", ColumnType.KEY)]
        public Int64 ClrNo { get; set; }

        [SWColumnAttribute("MTID")]
        public String MTID { get; set; }

        [SWColumnAttribute("F002")]
        public String F002 { get; set; }

        [SWColumnAttribute("F004")]
        public Decimal F004 { get; set; }

        [SWColumnAttribute("F012_S1")]
        public String F012_s1 { get; set; }

        [SWColumnAttribute("F024")]
        public String F024 { get; set; }

        [SWColumnAttribute("F025")]
        public String F025 { get; set; }

        [SWColumnAttribute("F031_S1")]
        public String F031_s1 { get; set; }

        [SWColumnAttribute("F031_S2")]
        public String F031_s2 { get; set; }

        [SWColumnAttribute("F031_S3")]
        public String F031_s3 { get; set; }

        [SWColumnAttribute("F031_S4")]
        public String F031_s4 { get; set; }

        [SWColumnAttribute("F031_S5")]
        public String F031_s5 { get; set; }

        [SWColumnAttribute("F049")]
        public String F049 { get; set; }

        [SWColumnAttribute("F072")]
        public String F072 { get; set; }

        [SWColumnAttribute("DISPUTE_NO")]
        public Int64 DisputeNo { get; set; }

        [SWColumnAttribute("PREV_CLEARING_NO")]
        public Int64 PrevClearingNo { get; set; }

        [SWColumnAttribute("PROV_GUID")]
        public Int64 ProvGuid { get; set; }  

        [SWColumnAttribute("OUT_STAT")]
        public String OutStat { get; set; }

        [SWColumnAttribute("IO_FLAG")]
        public String IoFlag { get; set; }

        [SWColumnAttribute("OUTGOING_DATE")]
        public DateTime OutgoingDate { get; set; }

        [SWColumnAttribute("OUTGOING_DATE2")]
        public DateTime OutgoingDate2 { get; set; }

        [SWColumnAttribute("INCOMING_DATE")]
        public DateTime IncomingDate { get; set; }

        public String Arn
        {
            get
            {
                return String.Concat(F031_s1,
                                     F031_s2,
                                     F031_s3,
                                     F031_s4,
                                     F031_s5);
            }
        }

        public DateTime TxnDate 
        {
            get { return DateTime.ParseExact(F012_s1, "yyMMdd", CultureInfo.InvariantCulture); } 
        }
        
    }
}
