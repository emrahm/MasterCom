using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class CaseDetailRequest
    {
        public CaseDetailRequest()
        {
            chargebackRefNum = new List<string>();
            fileAttachment = new FileAttachment();
        }
        /// <summary>
        /// Type of Case Filing. The following number values represent each case type. 1-Pre-arbitration, 2-Arbitration, 3-Pre-compliance, 4-Compliance
        /// </summary>
        public string caseType { get; set; }
        /// <summary>
        /// A list of Chargeback Reference numbers. This field is mandatory and applicable if the case type is pre-arbitration or arbitration or if the primary account number field is not populated
        /// </summary>
        public List<string> chargebackRefNum { get; set; }
        /// <summary>
        /// Customer filing number which is the filing party's internal number max length...15
        /// </summary>
        public string customerFilingNumber { get; set; }
        /// <summary>
        /// Violation code. This is only applicable and mandatory in case of pre-compliance and compliance types of cases
        /// </summary>
        public string violationCode { get; set; }
        /// <summary>
        /// Violation Date. This is only applicable and mandatory in case of pre-compliance and compliance types of cases. The format should be yyyy-MM-dd
        /// </summary>
        public string violationDate { get; set; }
        /// <summary>
        /// Dispute amount. Decimal is mandatory. The currency will be determined by the ICA region entered in the Filed ICA and Filed Against ICA. max length...9
        /// </summary>
        public string disputeAmount { get; set; }
        /// <summary>
        /// Currency Code. The following values are valid. USD, EUR, GBP, MXN
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// File name of image. The file name must be less than 16 characters in length. It must include alpha and numeric values. 
        /// The filename will have an extension matching one of the supported formats. File Formats are ZIP, JPG, TIFF, PDF.
        /// File converted to a base64 encoded string. File Formats are ZIP, JPG, TIFF, PDF. Note: ZIP files may contain these formats...JPG, TIFF, PDF
        /// </summary>
        public FileAttachment fileAttachment { get; set; }
        /// <summary>
        /// Filed Against ICA. max length...6
        /// </summary>
        public string filedAgainstIca { get; set; }
        /// <summary>
        /// Filing case as Issuer or Acquirer. Following values represents each type I-ISSUER A-ACQUIRER
        /// </summary>
        public string filingAs { get; set; }
        /// <summary>
        /// Filing ICA. max length...6
        /// </summary>
        public string filingIca { get; set; }
        /// <summary>
        /// Enter a Memo pertaining to the case. max length...13000
        /// </summary>
        public string memo { get; set; }
        /// <summary>
        /// The primary account number. This field is mandatory and applicable if the chargeback ref number field is not populated
        /// </summary>
        public String primaryAccountNum { get; set; }
        /// <summary>
        /// The acquirer reference number. This field is mandatory and applicable if case is created using primary account number
        /// </summary>
        public String acquirerRefNum { get; set; }
        /// <summary>
        /// Chargeback Reason Code. This is required and applicable for filing pre-arbitration and arbitration case. min length...2 max length...4. 
        /// The following values are valid. 
        /// 4863,4899,2001,2002,2003,2004,2005,2008,2011,2700,2701,2702,2703,2704,2705,2706,2707,2708,2709,2710,2711,2712,2713,
        /// 4801,4802,4807,4808,4809,4812,4831,4834,4835,4837,4840,4841,4842,4846,4847,4849,4850,4853,4854,4855,4856,4857,4859,
        /// 4860,4862,4900,4901,4902,4903,4905,4908,2000,4870,03,06,17,30,69,70,71,73,74,75,79,80,82,85,95,96,97,98,13,10,20,
        /// 24,25,26,27,28,29
        /// </summary>
        public string chargebackReasonCode { get; set; }
        /// <summary>
        /// Merchant name. This is required and applicable for filing pre-arbitration and arbitration case. max length...22
        /// </summary>
        public string merchantName { get; set; }
        /// <summary>
        /// Chargeback Date. This is only applicable and mandatory in case of pre-compliance and compliance types of cases with a violation code of 1.4. The format should be yyyy-MM-dd
        /// </summary>
        public String chargebackDate { get; set; }
        /// <summary>
        /// Credit Date. This is only applicable and mandatory in case of pre-compliance and compliance types of cases with a violation code of 1.4. The format should be yyyy-MM-dd
        /// </summary>
        public String creditDate { get; set; }
        /// <summary>
        /// Action to be performed on case. The following values are valid - ACCEPT, REJECT, REBUT, ESCALATE, WITHDRAW. Note : ESCALATE is applicable on pre compliance and pre arbitration cases.
        /// </summary>
        public string action { get; set; }
    }
}
