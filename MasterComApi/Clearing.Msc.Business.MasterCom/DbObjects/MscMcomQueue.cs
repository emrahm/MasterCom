using Smartway.Ocean.Framework.Pom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
	[SWTable("OC_MSC","MSC_MCOM_QUEUE")]
	public partial class MscMcomQueue : SWDbObject
	{
		#region Properties
		[SWColumn("GUID", ColumnType.GUID)]
		public long guid { get; set; }

		[SWColumn("STATUS", ColumnType.STATUS)]
		public short status { get; set; }

		[SWColumn("LASTUPDATED", ColumnType.LASTUPDATED)]
		public long lastUpdated { get; set; }

		[SWColumn("ACQUIRER_ID")]
		public string AcquirerId { get; set; }

		[SWColumn("ARN")]
		public string Arn { get; set; }

		[SWColumn("CARD_NO")]
		public string CardNo { get; set; }

		[SWColumn("CLAIM_ID")]
		public string ClaimId { get; set; }

		[SWColumn("CLAIM_TYPE")]
		public string ClaimType { get; set; }

		[SWColumn("CLAIM_AMOUNT")]
		public decimal ClaimAmount { get; set; }

		[SWColumn("CLAIM_CURRENCY")]
		public string ClaimCurrency { get; set; }

		[SWColumn("CLEARING_DUE_DATE")]
		public DateTime ClearingDueDate { get; set; }

		[SWColumn("CLEARING_NETWORK")]
		public string ClearingNetwork { get; set; }

		[SWColumn("CREATE_DATE")]
		public DateTime CreateDate { get; set; }

		[SWColumn("DUE_DATE")]
		public DateTime DueDate { get; set; }

		[SWColumn("TRANSACTION_ID")]
		public string TransactionId { get; set; }

		[SWColumn("IS_ACCURATE")]
		public bool IsAccurate { get; set; }

		[SWColumn("IS_ACQUIRER")]
		public bool IsAcquirer { get; set; }

		[SWColumn("IS_ISSUER")]
		public bool IsIssuer { get; set; }

		[SWColumn("IS_OPEN")]
		public bool IsOpen { get; set; }

		[SWColumn("ISSUER_ID")]
		public string IssuerId { get; set; }

		[SWColumn("LAST_MODIFIED_BY")]
		public string LastModifiedBy { get; set; }

		[SWColumn("LAST_MODIFIED_DATE")]
		public DateTime LastModifiedDate { get; set; }

		[SWColumn("MERCHANT_ID")]
		public string MerchantId { get; set; }

		[SWColumn("PROGRESS_STATE")]
		public string ProgressState { get; set; }

		[SWColumn("QUEUE_NAME")]
		public string QueueName { get; set; }

		[SWColumn("PROCESSED_STATUS")]
		public string ProcessedStatus { get; set; }

		[SWColumn("PROCESSED_DATE")]
		public DateTime ProcessedDate { get; set; }

		[SWColumn("INSERT_DATE")]
		public DateTime InsertDate { get; set; }

		[SWColumn("INSERT_TIME")]
		public int InsertTime { get; set; }

		#endregion
	}
}
