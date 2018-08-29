using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Utility;
using Moq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Utility
{
    [TestFixture]
    public class RestyClientTests
    {
        Mock<IRestClient> iRestClientMock = new Mock<IRestClient>();
        Mock<IMscMcomRequestRepository> iMscMcomRequestRepositoryMock = new Mock<IMscMcomRequestRepository>();
        String url = "https://tes.com/restapitest";
        IRestRequest restRequest = null;

        [SetUp]
        public void SetUp()
        {
            restRequest = new RestRequest(url, Method.GET);
            iRestClientMock.Setup(f => f.Execute(It.IsAny<IRestRequest>()))
          .Returns(new RestResponse());
        }

        [Test]
        public void Execute_WithNoBody_Execute()
        {
            //act
            RestyClient restyClient = new RestyClient(iMscMcomRequestRepositoryMock.Object,
                                                      iRestClientMock.Object);
            var result = restyClient.Execute(0, new Uri(url), restRequest);
            //assert
            Assert.That(result, Is.TypeOf<RestResponse>());
            iMscMcomRequestRepositoryMock.Verify(f => f.Create(It.IsAny<MscMcomRequest>()));
        }

        [Test]
        public void Execute_WithBody_Execute()
        {
            restRequest.Parameters.Add(new Parameter()
            {
                Type = ParameterType.RequestBody,
                Value = "{test=\"1\"}"
            });
            //act
            RestyClient restyClient = new RestyClient(iMscMcomRequestRepositoryMock.Object,
                                                      iRestClientMock.Object);
            var result = restyClient.Execute(0, new Uri(url), restRequest);
            //assert
            Assert.That(result, Is.TypeOf<RestResponse>());
            iMscMcomRequestRepositoryMock.Verify(f => f.Create(It.IsAny<MscMcomRequest>()));
        }
    }
}
