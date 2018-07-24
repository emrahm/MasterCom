using MasterCard.Api.Mastercom;
using MasterCard.Core;
using MasterCard.Core.Exceptions;
using MasterCard.Core.Model;
using MasterCard.Core.Security.OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterComTest
{
    public abstract class MasterComOperation
    {
        private static byte[] certeficate = null;
        protected abstract void RunOperation();

        public void Execute()
        {
            string consumerKey = "E12Oa2VeIBRLNjGqYibjip0JQqOc88y9eTrfkT8c214972e8!efe18b12a3ce40b989a2f887b971f85d0000000000000000";   // You should copy this from "My Keys" on your project page e.g. UTfbhDCSeNYvJpLL5l028sWL9it739PYh6LU5lZja15xcRpY!fd209e6c579dc9d7be52da93d35ae6b6c167c174690b72fa
            string keyAlias = "keyalias";   // For production: change this to the key alias you chose when you created your production key
            string keyPassword = "keystorepassword";   // For production: change this to the key alias you chose when you created your production key
            var path = MasterCard.Core.Util.GetCurrenyAssemblyPath(); // This returns the path to your assembly so it be used to locate your cert
            LoadCertificate();
            string certPath = @"C:\Users\emrah.mersinli\Desktop\MasterCOM\Isbank-sandbox.p12";
            ApiConfig.SetAuthentication(new OAuthAuthentication(consumerKey, certPath, keyAlias, keyPassword));   // You only need to set this once
            ApiConfig.SetDebug(true);   // Enable http wire logging
            ApiConfig.SetSandbox(true);
            try
            {
                RunOperation();
            }
            catch (ApiException e)
            {
                Err("HttpStatus: {0}", e.HttpStatus.ToString());
                Err("Message: {0}", e.Message);
                Err("ReasonCode: {0}", e.ReasonCode);
                Err("Source: {0}", e.Source);
                throw;
            }
            catch
            {
                throw;
            }
        }

        public static void Err(String message, String value)
        {
            Console.Error.WriteLine(message, value);
        }

        public static void Err(SmartMap response, String key)
        {
            Console.Error.WriteLine(key + "---> " + response[key]);
        }

        public static void Out(SmartMap response, String key)
        {
            Console.WriteLine(key + "---> " + response[key]);
        }

        public static void Out(Dictionary<String, Object> response, String key)
        {
            Console.WriteLine(key + "---> " + response[key]);
        }

        public static void LoadCertificate()
        {
            if (certeficate == null)
            {
                string certPath = @"C:\Users\emrah.mersinli\Desktop\MasterCOM\Isbank-sandbox.p12";  
                certeficate = File.ReadAllBytes(certPath);
            }
        }
    }
}
