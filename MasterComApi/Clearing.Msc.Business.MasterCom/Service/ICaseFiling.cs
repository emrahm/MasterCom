using Clearing.Msc.Business.MasterCom.ModelData;
using System;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Model
{
    interface ICaseFiling
    {
        List<CaseFilingResponse> CaseStatus(List<CaseIdRequestResponse> caseIdList);
        CaseIdRequestResponse CreateCase(CaseDetailRequest caseDetail);
        CaseDetailRetrieveDocument RetrieveDocuments(string caseId);
        CaseIdRequestResponse UpdateCase(string caseId, CaseDetailRequest caseDetail);
    }
}
