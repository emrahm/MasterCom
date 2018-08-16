using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class CaseFilingDetailsHistory
    {
        public string caseFilingStatus { get; set; }
        public CaseFilingDetails caseFilingDetails { get; set; }
        public List<CaseFilingRespHistory> caseFilingRespHistory { get; set; }
    }
}
