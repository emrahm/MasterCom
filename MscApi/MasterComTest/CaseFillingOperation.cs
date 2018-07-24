using MasterCard.Api.Mastercom;
using MasterCard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterComTest
{
    public class CaseFillingOperation : MasterComOperation
    {
        protected override void RunOperation()
        {
            RequestMap map = new RequestMap();
            map.Set("caseType", "4");
            map.Set("chargebackRefNum[0]", "1111423456, 2222123456");
            map.Set("customerFilingNumber", "5482");
            map.Set("violationCode", "D.2");
            map.Set("violationDate", "2017-11-13");
            map.Set("disputeAmount", "20,.000");
            map.Set("currencyCode", "LLL");
            map.Set("fileAttachment.filename", "test.tif");
            map.Set("fileAttachment.file", "sample file");
            map.Set("filedAgainstIca", "004321");
            map.Set("filingAs", "A");
            map.Set("filingIca", "001234");
            map.Set("memo", "This is a test memo");

            SmartMap response = CaseFiling.create(map);
            String caseId = response.Get("caseId").ToString();
        }
    }
}
