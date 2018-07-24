using MasterCard.Api.Mastercom;
using MasterCard.Core;
using MasterCard.Core.Exceptions;
using MasterCard.Core.Model;
using MasterCard.Core.Security.OAuth;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MasterComTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String ff = "ee";

            //RetrieveQueueNamesOperation queues = new RetrieveQueueNamesOperation();
            //queues.Execute();

            /*
                GET https://sandbox.api.mastercard.com/mastercom/v1/queues?queue-name=Closed&Format=JSON HTTP/1.1
                Accept: application/json
                Content-Type: application/json
                Authorization: OAuth oauth_consumer_key="E12Oa2VeIBRLNjGqYibjip0JQqOc88y9eTrfkT8c214972e8%21efe18b12a3ce40b989a2f887b971f85d0000000000000000",
                               oauth_nonce="rGEyWdAa6ZJoP61Mj",
                               oauth_signature="GzVSbs%2BOWfWH66vjhpX1U96h3XTkh0qhQ2ODpAb7T2AYqoTxuau4u%2FZNN5r%2Bg26keK5tfDUTj16BBs%2BXaifQBDnPr7pMgOE0QJ59oHi5haQKt7NneYmXvjoXJOtwMQmY3rqq6ym27XsdREeKLWNToo39lPiI0gZZqyFypunCmknVvX2UJKdjCTTvOCDd3q%2BJ5ACNLewyQ4yr67Bu6r%2B4JmaiVbc5XvwiAwe8Pyy%2FVAsirIy9%2BUz86jtCW6wJ%2BJ%2FFXG8mMulpkNqP40kk1j94RO%2Flw%2Bk2%2FYkhlLJZIaalDpVmrvD25ZU7%2FlIPtdukaIQua%2FYpx7ZktMQNxZrfs73Wow%3D%3D",
                               oauth_signature_method="RSA-SHA256",
                               oauth_timestamp="1530704318",
                               oauth_version="1.0"
                User-Agent: RestSharp/105.2.3.0
                Host: sandbox.api.mastercard.com
                Accept-Encoding: gzip, deflate
                Connection: Keep-Alive
             
             */
            CaseFillingOperation claims = new CaseFillingOperation();
            claims.Execute();

            //RunOperation();
        }

        private static void RunOperation()
        {
            string keyPassword = "keystorepassword";   
            string certPath = @"C:\Users\emrah.mersinli\Desktop\MasterCOM\Isbank-sandbox.p12";
            
            X509Certificate2 cert = new X509Certificate2(certPath, keyPassword, X509KeyStorageFlags.Exportable);
            AsymmetricAlgorithm privateKey = cert.PrivateKey;

            Dictionary<String, Object> dictionary2 = new Dictionary<string, object>();

            Uri uri = new Uri("https://sandbox.api.mastercard.com/mastercom/v1/queues?queue-name=Closed&Format=JSON");

            RestRequest restyRequest = new RestRequest(uri, Method.GET);
            restyRequest.AddHeader("Accept", "application/json");
            restyRequest.AddHeader("Content-Type", "application/json");
           // restyRequest.AddHeader("User-Agent", "CSharp-SDK/" + metadata.Version);
            foreach (var item in dictionary2)
                restyRequest.AddHeader(item.Key, item.Value.ToString());
           // ApiConfig.GetAuthentication().SignRequest(url, (IRestRequest)restyRequest);
            //restyRequest.AbsoluteUrl = url;
            //restyRequest.BaseUrl = uri;
            //restyRequest.interceptor = cryptographyInterceptor;

            IRestClient restClient;

            

            string consumerKey = "E12Oa2VeIBRLNjGqYibjip0JQqOc88y9eTrfkT8c214972e8!efe18b12a3ce40b989a2f887b971f85d0000000000000000";  
            
        }
    }
}
