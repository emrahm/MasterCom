using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Model
{
    /*
"/mastercom/v1/cases" "create"
"/mastercom/v1/cases/{case-id}/documents", "query"
"/mastercom/v1/cases/status", "update"
"/mastercom/v1/cases/{case-id}", "update"
     
     */
    public class CaseFiling
    {
        IApiController _apiController = null;
        public CaseFiling(IApiController apiController)
        {
            _apiController = apiController;
        }

        public int CreateCase(CaseDetail caseDetail)
        {
            
            return 0;
        }
    }
}
