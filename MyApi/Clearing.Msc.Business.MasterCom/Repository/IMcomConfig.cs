using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Repository
{
    public interface IMcomConfig
    { 
        string ConsumerKey { get; set; }
        string KeyPassword { get; set; }
        string CertPath { get; set; }
        string BaseUrl { get; set; }
        string UserAgentVersion { get; set; }
        string UrlVersionNumber { get; set; }
        string Environment { get; set; }
    }
}
