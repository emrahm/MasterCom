using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface ICaseFiling
    {
        List<CaseFilingResponse> CaseStatus(long refKey, List<CaseIdRequestResponse> caseIdList);
        CaseIdRequestResponse CreateCase(long refKey, CaseDetailRequest caseDetail);
        CaseDetailRetrieveDocument RetrieveDocuments(long refKey, string caseId);
        CaseIdRequestResponse UpdateCase(long refKey, string caseId, CaseDetailRequest caseDetail);
    }
}
