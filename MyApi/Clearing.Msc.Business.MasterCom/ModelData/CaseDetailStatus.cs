using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    /// <summary>
    /// Root object of case id
    /// </summary>
    public class CaseDetailStatus
    {
        /// <summary>
        /// Case id list
        /// </summary>
        public List<CaseIdRequestResponse> caseFilingList { get; set; }
    }
}
