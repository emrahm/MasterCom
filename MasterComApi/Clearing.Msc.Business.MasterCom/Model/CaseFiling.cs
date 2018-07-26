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

        /// <summary>
        /// generate a new Case Filing
        /// </summary>
        /// <param name="caseDetail"></param>
        /// <returns>The case filing id</returns>
        public CaseIdRequestResponse CreateCase(CaseDetailRequest caseDetail)
        {
            return _apiController.Create<CaseIdRequestResponse>("cases", caseDetail);
        }
        /// <summary>
        ///  updates a Case Filing record 
        /// </summary>
        /// <param name="caseId">Case Filing Id. max length...9</param>
        /// <param name="caseDetail">Action to be performed on case. The following values are valid - ACCEPT, REJECT, REBUT, ESCALATE, WITHDRAW. Note : ESCALATE is applicable on pre compliance and pre arbitration cases.</param>
        /// <returns>The case filing id</returns>
        public CaseIdRequestResponse UpdateCase(String caseId, 
                                                CaseDetailRequest caseDetail)
        {
            return _apiController.Update<CaseIdRequestResponse>(String.Format("cases/{0}", caseId), null, caseDetail);
        }
        /// <summary>
        ///  retrieves the processing status of a case filing image
        /// </summary>
        /// <param name="caseIdList"></param>
        /// <returns>Status of case filing images. Valid responses are COMPLETED, FAILED, PENDING, UNAVAILABLE</returns>
        public List<CaseFilingResponse> CaseStatus(List<CaseIdRequestResponse> caseIdList)
        {
            CaseDetailStatus caseDetailStatus = new CaseDetailStatus();
            caseDetailStatus.caseFilingList = caseIdList;
            return _apiController.Update<CaseFilingResponseList>("cases/status", null, caseDetailStatus).caseFilingResponseList;
        }
        /// <summary>
        ///  retrieves all documentation for a Case Filing record
        ///  File Format. The following values are valid - ORIGINAL, MERGED_TIFF, MERGED_PDF
        ///  method set format to ORJINAL. Other format not used for us.
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns>File converted to a base64 encoded string. File Format is ZIP Note: ZIP file may contain these formats...JPG, TIFF, PDF</returns>
        public CaseDetailRetrieveDocument RetrieveDocuments(String caseId)
        {
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            parameters.Add("format", "ORIGINAL");
            return _apiController.Get<CaseDetailRetrieveDocument>(String.Format("cases/{0}/documents", caseId), parameters);
        }
    }
}
