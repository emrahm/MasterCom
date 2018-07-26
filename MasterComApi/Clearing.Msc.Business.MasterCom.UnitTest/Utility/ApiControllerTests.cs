using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Security;
using Clearing.Msc.Business.MasterCom.Utility;
using Moq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Utility
{
    [TestFixture]
    public class ApiControllerTests
    {
        IMcomConfig iMcomConfig = new MscMcomConfig();
        Mock<IAuthAuthentication> iAuthAuthenticationMock = new Mock<IAuthAuthentication>();
        Mock<IRestClient> iRestClientMock = new Mock<IRestClient>();
        ApiController apiController = null;
        readonly String[][] parameter = new String[][] { new String[] { "queue-name", "Closed" } };
        [SetUp]
        public void SetUp()
        {
            apiController = new ApiController(iMcomConfig,
                                                         iAuthAuthenticationMock.Object,
                                                         iRestClientMock.Object);
            iMcomConfig.ConsumerKey = "E12Oa2VeIBRLNjGqYibjip0JQqOc88y9eTrfkT8c214972e8!efe18b12a3ce40b989a2f887b971f85d0000000000000000";
            iMcomConfig.KeyPassword = "keystorepassword";
            iMcomConfig.CertPath = @"C:\Users\emrah.mersinli\Desktop\MasterCOM\Isbank-sandbox.p12";
            iMcomConfig.BaseUrl = "https://sandbox.api.mastercard.com";
            iMcomConfig.UserAgentVersion = "MasterCard-Mastercom:0.0.5";
            iMcomConfig.UrlVersionNumber = "/mastercom/v1/";
            iMcomConfig.Environment = "SANDBOX";
        }

        [Test]
        public void Get_GetResponse_ReturnQueueList()
        {
            //arrange  
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("k1", "v1");

            List<ResponseQueue> responseQueueList = new List<ResponseQueue>();
            responseQueueList.Add(new ResponseQueue());

            iRestClientMock.Setup(f => f.Execute(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<List<ResponseQueue>>
                {
                    Content = responseQueueList.ToJson(),
                    StatusCode = System.Net.HttpStatusCode.OK,
                });

            //act
            var result = apiController.Get<List<ResponseQueue>>("queues", parameters);
            //assert
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void Get_GetResponse_ReturnResponseErrorContent()
        {
            String errorMessage = "testError";
            ResponseErrorContent content = new ResponseErrorContent();
            content.Errors = new Errors() { Error = new List<ResponseError>() };
            content.Errors.Error.Add(new ResponseError() { Description = errorMessage });

            iRestClientMock.Setup(f => f.Execute(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<List<ResponseQueue>>
                {
                    Content = content.ToJson(),
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                });

            //act 
            //assert>
            Assert.That(() => apiController.Get<List<ResponseQueue>>("queues", null), 
                                                                     Throws.Exception.Message.Contain(errorMessage)); 
        }


        [Test]
        public void Get_ResponseIsNotResponseErrorContent_ThrowJsonException()
        {
            //arrange 
            String jsonErrorData = @"{  
                                       ""Errors"":[  
                                          {  
                                             ""RequestId"":""ad89809c-a79a-0e26-cf4a-9a393eff0a41"",
                                             ""Source"":""SERVICE_ERROR"",
                                             ""ReasonCode"":""SERVICE_FAILED"",
                                             ""Description"":""Service failed to complete."",
                                             ""Recoverable"":false,
                                             ""Details"":[  
                                                {  
                                                   ""Name"":""ErrorDetailCode"",
                                                   ""Value"":""100002""
                                                }
                                             ]
                                          }";
            iRestClientMock.Setup(f => f.Execute(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<List<ResponseQueue>>
                {
                    Content = jsonErrorData,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                });
            //act 
            //assert>
            Assert.That(() => apiController.Get<List<ResponseQueue>>("queues", null), Throws.Exception.Message.Contain("ad89809c-a79a-0e26-cf4a-9a393eff0a41"));
        }


        [Test]
        public void Create_CreateACaseDetail_ReturnCaseDetailResponse()
        {
            iRestClientMock.Setup(f => f.Execute(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<CaseIdRequestResponse>
                {
                    Content = new CaseIdRequestResponse().ToJson(),
                    StatusCode = System.Net.HttpStatusCode.OK,
                });

            //act 
            var result = apiController.Create<CaseIdRequestResponse>("cases", new CaseDetailRequest());
            //assert> 
            Assert.That(result, Is.TypeOf<CaseIdRequestResponse>());
        }
    }
}
