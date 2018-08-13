using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Security;
using Moq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Security
{
    [TestFixture]
    public class OAuthAuthenticationTests
    {
        String xmlStringPrivateKey = "<RSAKeyValue><Modulus>k4z3KB+kp67PTnaxK3DMEVQMibIGcRqcmSfsrGOlXnFhg2o7bkFX3ZZJmVtYWTiHa4kt/STOtoSiaeKni3gQPc3ZMvaHMIIQrVR2YcwPpqnSYCeyiPZdLabSRAYx+LUO+gM+WSygY7GdLimm+pB5se46ILQMrG5y5ZGc0uoosZQFvi611elfg3N/SF2N+kjG6L7m+7ueLoqhdLTta3QCNvHP62XI6D0Iwf4y9thh3qTsdeARJQ06sVBmWvMLmYVyQrKAN1PyzWIzJ3Dpv0PdPryWRJS/q/stWpyiovQWhr47KFdtSp2wvXDiekIjf/swxvjRj5xHzkV4rB9vdKPVnw==</Modulus><Exponent>AQAB</Exponent><P>w2GYvYnN3JAjm69AEqJ5zn8mFPr/6a/Mhh6VEWwxlJNASMci3i1+kOAPs1+qV3wTCgKmqG2BmC2OOJj0T/WgYX5J5sXsM+KRjA7W517Rv015+4LytoKg2gj5e5EV+xPC8SyP0I6NHc/SzNo5/JjwM9k5i8ZOa8Z5lweZLCqOMB0=</P><Q>wVRdANw3su22kV8mdYcBPXuFY08WUW+g+0Bvi1e5IiTomXl710b5zaGtuIHS6rb1Dbq+cFkzMteloNOYcrGEJdspezLzE9QZ/odNUwwKjplPFa/61XuA24iODfh0UYgTaOhpH1nyz6wheiPp597eGFCa30FQLYFGb1EpqFIqZ+s=</Q><DP>lA0XjcCnoxQCN43D8pr1zBkjRVCxrWXOiG8SLGKc62Xtl3h2nn9A4g03OIgsbyCQ2MwLd6OLSUJz+8VDlHefMWFeJKYkB2kPO19fT3HVZK4T2hdvTgeMVcvpKM5XJqvh05kd3T64BjgeF6bhu9w0YEWhyp3ZfOen6V8TnZkdp60=</DP><DQ>bw8XnjbjiFYmWrxeS4WSoM8kgTgdigqmX69UZKewIn0xYXj4O2L6fbYzJZrunwcbHxf37nJPhxV6gDkNilWPpG+SFMPf/7QIer8fHGX+aoyHcd32Kk0YaQS5Fi10JKIXBFz+hpQVeFdZo+CdriXJUA596WKLvJhW7fuiAp+w3KE=</DQ><InverseQ>wYO+X41Fcg9U7J7MSp8eX0WA1vSAL1RDK73CtjWVo7h1DynF6sb/5oVV4n41YffvECPc2Ni4+I+Rpe5QUedQUWIkz5MMwS0bkDL9psv31VD7hLTLZvNX4sqbZqEz9vzrJi9DJpy2d/tunP6zTZBmurZydTDo6RJE4fKFNoZi93c=</InverseQ><D>BPia2x81zPB2y430KiKCvZK3WWxGC0l6PS67KpOw3p2zS1oo5m4NJ8oIcMJDF75v0Y+tnPnAfSW60xZvzqMc6PgmeTEVHO1E4pIV6vWVEWhnThYITdT/DqqwKtqKlHaFKqcxUo/OV42EXinJFmgHsZb1HmTyiFywQkvFnNWGyXTGJCDHNV3XhFjGDG3mJELKKXs+H34S+E9i5VgrX3mgsYTTfQ13+k6F7eRA0NdhGccO46hA9ezE1mef1+haTNA3GeSmgDQuD3XX+A09WvqiObRap12awCCziHLNha2qv99QFfb5AnU+PtaT5nqeZQgeK60uRyak2qNkVqqoDfI/AQ==</D></RSAKeyValue>";
        OAuthAuthentication oAuthAuthentication = null;
        MscMcomConfig iMcomConfig = null;
        Mock<ICerteficateReader> iCerteficateReaderMock = null;
        IRestRequest iRestRequest = null;
        Uri uri = new Uri("https://test.com/test");


        [SetUp]
        public void SetUp()
        {
            iMcomConfig = new MscMcomConfig();
            iMcomConfig.BaseUrl = "BaseUrl";
            iMcomConfig.ConsumerKey = "ConsumerKey";
            iMcomConfig.KeyPassword = "KeyPassword";
            iMcomConfig.CertPath = @"CertPath";
            iMcomConfig.BaseUrl = "BaseUrl";
            iMcomConfig.UserAgentVersion = "UserAgentVersion";
            iMcomConfig.UrlVersionNumber = "UrlVersionNumber";
            iMcomConfig.Environment = "Environment";

            iCerteficateReaderMock = new Mock<ICerteficateReader>();
            iCerteficateReaderMock.Setup(f => f.GetPrivateKey(It.IsAny<String>(), It.IsAny<String>()))
                                  .Returns(xmlStringPrivateKey);

            oAuthAuthentication = new OAuthAuthentication(iMcomConfig,
                                                          iCerteficateReaderMock.Object,
                                                          SecurityProtocolType.Tls12);
            iRestRequest = new RestRequest(uri, Method.GET);
        }

        [Test]
        public void SignRequest_Enchiper_Authorization()
        {
            //arrange
            //act
            oAuthAuthentication.SignRequest(uri, iRestRequest);
            //assert
            Assert.That(iRestRequest.Parameters.Count, Is.EqualTo(1));
            Assert.That(iRestRequest.Parameters[0].Name, Is.EqualTo("Authorization"));
            Assert.That(iRestRequest.Parameters[0].Value, Does.Contain("oauth_nonce"));
            Assert.That(iRestRequest.Parameters[0].Value, Does.Contain("oauth_timestamp"));
            Assert.That(iRestRequest.Parameters[0].Value, Does.Contain("oauth_signature_method"));
            Assert.That(iRestRequest.Parameters[0].Value, Does.Contain("oauth_version"));
            Assert.That(iRestRequest.Parameters[0].Value, Does.Contain("oauth_signature"));  
        }

        [Test]
        public void SignRequest_EnchiperWithBody_AuthorizationAndBody()
        {
            //arrange
            iRestRequest.AddBody(new ResponseQueue());
            //act
            oAuthAuthentication.SignRequest(uri, iRestRequest);
            //assert
            Assert.That(iRestRequest.Parameters.Count, Is.EqualTo(2));

            Assert.That(iRestRequest.Parameters[0].Type.ToString(), Is.EqualTo("RequestBody"));
            Assert.That(iRestRequest.Parameters[0].Value, Does.Contain("ResponseQueue"));


            Assert.That(iRestRequest.Parameters[1].Type.ToString(), Is.EqualTo("HttpHeader"));
            Assert.That(iRestRequest.Parameters[1].Name, Is.EqualTo("Authorization"));
            Assert.That(iRestRequest.Parameters[1].Value, Does.Contain("oauth_nonce"));
            Assert.That(iRestRequest.Parameters[1].Value, Does.Contain("oauth_timestamp"));
            Assert.That(iRestRequest.Parameters[1].Value, Does.Contain("oauth_signature_method"));
            Assert.That(iRestRequest.Parameters[1].Value, Does.Contain("oauth_version"));
            Assert.That(iRestRequest.Parameters[1].Value, Does.Contain("oauth_signature"));
        }
    }
}
