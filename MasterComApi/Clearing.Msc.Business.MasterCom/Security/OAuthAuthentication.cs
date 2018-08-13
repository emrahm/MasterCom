using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Clearing.Msc.Business.MasterCom.Security
{
    public class OAuthAuthentication : IAuthAuthentication
    {
        private String xmlStringPrivateKey;
        private UTF8Encoding encoder; 
        private readonly string clientId;
        private readonly String filePath;
        private readonly String password;
        private static Random random = new Random();
        private const string VALID_CHAR = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public OAuthAuthentication(MscMcomConfig iMcomConfig,
                                   ICerteficateReader certeficateReader,
                                   SecurityProtocolType securityProtocolType)
        {
            this.clientId = iMcomConfig.ConsumerKey;
            this.password = iMcomConfig.KeyPassword;
            this.filePath = iMcomConfig.CertPath;
            this.xmlStringPrivateKey = certeficateReader.GetPrivateKey(filePath, password);
            this.encoder = new UTF8Encoding();
            ServicePointManager.SecurityProtocol = securityProtocolType;
        }

        public void SignRequest(Uri uri, IRestRequest request)
        {
            string signature = GenerateSignature(uri, request);
            request.AddHeader("Authorization", signature);
        } 

        private string SignMessage(string message)
        { 
            RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
            cryptoServiceProvider.FromXmlString(xmlStringPrivateKey);  
            Byte[] hash = cryptoServiceProvider.SignHash(Util.Sha256Encode(message), 
                                                         CryptoConfig.MapNameToOID("SHA256"));
            return Convert.ToBase64String(hash);
        }
         
        private string GenerateSignature(Uri uri,
                                         IRestRequest request)
        {
            OAuthParameters oauthParameters = new OAuthParameters();
            oauthParameters.setOAuthConsumerKey(clientId);
            oauthParameters.setOAuthNonce(GetNonce());
            oauthParameters.setOAuthTimestamp(GetTimestamp());
            oauthParameters.setOAuthSignatureMethod("RSA-SHA256");
            oauthParameters.setOAuthVersion("1.0");
            oauthParameters.setOAuthBodyHash(GetBodyHash(request));
            String baseString = GetBaseString(uri.ToString(), request.Method.ToString(), oauthParameters.getBaseParameters());
            oauthParameters.setOAuthSignature(SignMessage(baseString));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var baseParameter in oauthParameters.getBaseParameters())
            {
                if (stringBuilder.Length == 0)
                    stringBuilder.Append(OAuthParameters.OAUTH_KEY).Append(" ");
                else
                    stringBuilder.Append(",");
                stringBuilder.Append(baseParameter.Key).Append("=\"").Append(Util.UriRfc3986(baseParameter.Value)).Append("\"");
            }
            return stringBuilder.ToString();
        } 
       
        private static string GetNonce()
        {
            int num = 17;
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < num; ++index)
                stringBuilder.Append(VALID_CHAR[random.Next(0, VALID_CHAR.Length - 1)]);
            return stringBuilder.ToString();
        }

        private static string GetTimestamp()
        {
            DateTime utcNow = DateTime.UtcNow;
            long ticks1 = utcNow.Ticks;
            utcNow = DateTime.Parse("01/01/1970 00:00:00");
            long ticks2 = utcNow.Ticks;
            return ((ticks1 - ticks2) / 10000000L).ToString();
        }

        private static string GetBaseString(string requestUrl, string httpMethod, Dictionary<string, string> oauthParameters)
        {
            return Util.UriRfc3986(httpMethod.ToUpper()) +
                   "&" +
                   Util.UriRfc3986(Util.NormalizeUrl(requestUrl)) +
                   "&" +
                   Util.UriRfc3986(Util.NormalizeParameters(requestUrl, oauthParameters));
        }
  
        private static string GetBodyHash(IRestRequest request)
        {
            Parameter body = request.Parameters.FirstOrDefault<Parameter>(p => p.Type == ParameterType.RequestBody);
            if (body != null)
            {
                return Util.Base64Encode(Util.Sha256Encode(body.Value.ToString()));
            }
            return String.Empty;
        }
    }
}
