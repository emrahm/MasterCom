using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class RetrievalFulfillmentRequest
    {
        public RetrievalFulfillmentRequest()
        {
            fileAttachment = new FileAttachment();
        }
        public String acquirerResponseCd { get; set; }
        public String docTypeIndicator { get; set; }
        public String memo { get; set; }
        public FileAttachment fileAttachment { get; set; }
    }
}
