using RestSharp;
using System;

namespace Clearing.Msc.Business.MasterCom.Utility
{
    public interface IRestyClient
    {
        IRestResponse Execute(long refKey, Uri url, IRestRequest restRequest);
    }
}
