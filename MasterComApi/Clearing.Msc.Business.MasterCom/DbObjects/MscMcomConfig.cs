using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    public class MscMcomConfig : IMcomConfig
    {
        public string ConsumerKey { get; set; }

        public string KeyPassword { get; set; }

        public string CertPath { get; set; }

        public string BaseUrl { get; set; }

        public string UserAgentVersion { get; set; }

        public string UrlVersionNumber { get; set; }

        public string Environment { get; set; }
    }
}
