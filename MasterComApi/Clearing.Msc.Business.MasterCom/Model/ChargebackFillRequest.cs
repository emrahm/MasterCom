using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{ 
    public class ChargebackFillRequest
    {
        public ChargebackFillRequest()
        {
            fileAttachment = new FileAttachment();
        }
        /// <summary>
        /// The chargeback currency. The data should be standard currency alpha code
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Document Indicator. Define if the document is required for the dispute. Valid values...true, false
        /// </summary>
        public string documentIndicator { get; set; }
        /// <summary>
        /// Member message text to be used for the chargeback. max length...100
        /// </summary>
        public string messageText { get; set; }
        /// <summary>
        /// Chargeback Amount. max length...12
        /// </summary>
        public string amount { get; set; }  
        /// <summary>
        /// File Attachment
        /// </summary>
        public FileAttachment fileAttachment { get; set; }
        /// <summary>
        /// Chargeback Reason Code
        /// </summary>
        public string reasonCode { get; set; }
        /// <summary>
        /// Provide the chargeback. The following values are valid - CHARGEBACK, SECOND_PRESENTMENT, ARB_CHARGEBACK
        /// </summary>
        public string chargebackType { get; set; }
        /// <summary>
        /// Memo. max length...100
        /// </summary>
        public string memo { get; set; }
    }
}
