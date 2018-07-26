using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    
    public class CaseFilingResponse
    {
        /// <summary>
        /// Case Id
        /// </summary>
        public string caseId { get; set; }
        /// <summary>
        /// Status of case filing images. Valid responses are COMPLETED, FAILED, PENDING, UNAVAILABLE
        /// </summary>
        public string status { get; set; }
    }

    /// <summary>
    /// Root object
    /// </summary>
    public class CaseFilingResponseList
    {
        /// <summary>
        /// A list of case filing statuses
        /// </summary>
        public List<CaseFilingResponse> caseFilingResponseList { get; set; }
    }
}
