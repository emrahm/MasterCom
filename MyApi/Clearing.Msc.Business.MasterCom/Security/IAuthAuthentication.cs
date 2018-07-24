using RestSharp;
using System;
using System.Net;
using System.Security.Cryptography;
namespace Clearing.Msc.Business.MasterCom.Security
{
    public interface IAuthAuthentication
    { 
        void SignRequest(Uri uri, IRestRequest request);
    }
}
