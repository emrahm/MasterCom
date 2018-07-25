using Clearing.Msc.Business.MasterCom.Model;
using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Security;
using Clearing.Msc.Business.MasterCom.Utility;
using Moq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Model
{
    [TestFixture]
    public class QueuesTests
    {
        IApiController apiController = null;
        [SetUp]
        public void SetUp()
        {

            IMComConfigRepository iMComConfigRepository = new MComConfigRepository();
            apiController = new ApiController(iMComConfigRepository.GetMComConfig(),
                                              new OAuthAuthentication(iMComConfigRepository.GetMComConfig(),
                                                                      new CerteficateReader(),
                                                                      SecurityProtocolType.Tls12),
                                              new RestClient());

        }

        [Test]
        [TestCase("Closed")]
        public void Ent_GetQueries_GetResponseQueueList_GetClosedQueues(String queueName)
        {
            //arrange 
            //act
            Queues queues = new Queues(apiController);
            var result = queues.GetQueues(queueName);
            //assert
            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}
