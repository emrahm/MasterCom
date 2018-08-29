using Smartway.Ocean.Framework.Pom;
using System;
using System.Collections.Generic;
using System.Text; 

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
	[SWTable("OC_MSC","MSC_MCOM_TQR4")]
	public partial class MscMcomTqr4 : SWDbObject
	{
		#region Properties
		[SWColumn("GUID", ColumnType.GUID)]
		public long guid { get; set; }

		[SWColumn("STATUS", ColumnType.STATUS)]
		public short status { get; set; }

		[SWColumn("LASTUPDATED", ColumnType.LASTUPDATED)]
		public long lastUpdated { get; set; }

		[SWColumn("CLR_NO")]
		public long ClrNo { get; set; }

		[SWColumn("P0105")]
		public string P0105 { get; set; }

		[SWColumn("F071")]
		public string F071 { get; set; }

		[SWColumn("CLAIM_ID")]
		public string ClaimId { get; set; }

		[SWColumn("EVENT_ID")]
		public string EventId { get; set; }

		[SWColumn("F095")]
		public string F095 { get; set; }

		[SWColumn("F031")]
		public string F031 { get; set; }

		[SWColumn("MTID")]
		public string Mtid { get; set; }

		[SWColumn("F002")]
		public string F002 { get; set; }

		[SWColumn("F003")]
		public string F003 { get; set; }

		[SWColumn("F024")]
		public string F024 { get; set; }

		[SWColumn("F025")]
		public string F025 { get; set; }

		[SWColumn("F004")]
		public decimal F004 { get; set; }

		[SWColumn("F005")]
		public decimal F005 { get; set; }

		[SWColumn("F006")]
		public decimal F006 { get; set; }

		[SWColumn("F049")]
		public string F049 { get; set; }

		[SWColumn("F050")]
		public string F050 { get; set; }

		[SWColumn("F051")]
		public string F051 { get; set; }

		[SWColumn("P0148")]
		public string P0148 { get; set; }

		[SWColumn("F037")]
		public string F037 { get; set; }

		[SWColumn("F026")]
		public string F026 { get; set; }

		[SWColumn("F042")]
		public string F042 { get; set; }

		[SWColumn("F043")]
		public string F043 { get; set; }

		[SWColumn("F012_S1")]
		public string F012S1 { get; set; }

		[SWColumn("F012_S2")]
		public string F012S2 { get; set; }

		[SWColumn("F094")]
		public string F094 { get; set; }

		[SWColumn("F093")]
		public string F093 { get; set; }

		[SWColumn("REJECT_STATUS")]
		public string RejectStatus { get; set; }

		[SWColumn("REJECT_REASON")]
		public string RejectReason { get; set; }

		[SWColumn("P0025")]
		public string P0025 { get; set; }

		[SWColumn("INCOMING_DATE")]
		public DateTime IncomingDate { get; set; }

		[SWColumn("INSERT_DATE_TIME", ColumnType.INSERT_DATE_TIME)]
		public DateTime InsertDateTime { get; set; }

		#endregion
	}
}
