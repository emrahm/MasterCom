using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Security
{
    public interface ICerteficateReader
    {
        /// <summary>
        /// Getting xml string.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        String GetPrivateKey(string filePath, string password);
    }
}
