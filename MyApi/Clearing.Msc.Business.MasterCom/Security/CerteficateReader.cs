using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Security
{
    public class CerteficateReader : ICerteficateReader
    { 
        public String GetPrivateKey(string filePath, string password)
        {
            var cert = new X509Certificate2(filePath, password, X509KeyStorageFlags.Exportable);
            return cert.PrivateKey.ToXmlString(true);
        }
    }
}
