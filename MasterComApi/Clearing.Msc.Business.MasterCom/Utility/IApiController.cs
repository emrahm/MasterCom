using System;
using System.Collections.Generic;
namespace Clearing.Msc.Business.MasterCom.Utility
{
    public interface IApiController
    {
        T Get<T>(long refKey, string restUrl, Dictionary<string, string> parameterQuery);

        T Create<T>(long refKey, String restUrl, Object fromBody);

        T Update<T>(long refKey, string restUrl, Dictionary<string, string> parameters, Object caseDetail);
    }
}
