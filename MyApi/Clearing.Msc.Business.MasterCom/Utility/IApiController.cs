using System;
using System.Collections.Generic;
namespace Clearing.Msc.Business.MasterCom.Utility
{
    public interface IApiController
    {
        T Get<T>(string restUrl, Dictionary<string, string> parameterQuery);

        object Create<T1>(string p, Dictionary<string, string> dictionary);
    }
}
