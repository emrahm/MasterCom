using System;
using System.Collections.Generic;
namespace Clearing.Msc.Business.MasterCom.Utility
{
    public interface IApiController
    {
        T Get<T>(string restUrl, Dictionary<string, string> parameterQuery);

        T Create<T>(String restUrl, Object fromBody);
    }
}
