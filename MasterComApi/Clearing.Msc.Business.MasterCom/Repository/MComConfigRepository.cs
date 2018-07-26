using Clearing.Msc.Business.MasterCom.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Repository
{
    public class MComConfigRepository : IMComConfigRepository 
    {
        public IMcomConfig GetMComConfig()
        {
            //Db connecttion
            var iMComConfig = new MscMcomConfig();
            iMComConfig.ConsumerKey = "E12Oa2VeIBRLNjGqYibjip0JQqOc88y9eTrfkT8c214972e8!efe18b12a3ce40b989a2f887b971f85d0000000000000000";
            iMComConfig.KeyPassword = "keystorepassword";
            iMComConfig.CertPath = @"C:\Users\emrah.mersinli\Desktop\MasterCOM\Isbank-sandbox.p12";
            iMComConfig.BaseUrl = "https://sandbox.api.mastercard.com";
            iMComConfig.UserAgentVersion = "MasterCard-Mastercom:0.0.5";
            iMComConfig.UrlVersionNumber = "/mastercom/v1/";
            iMComConfig.Environment = "SANDBOX";
            return iMComConfig;
        }
    }
}
