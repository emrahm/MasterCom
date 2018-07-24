using Clearing.Msc.Business.MasterCom.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Utility
{
    [TestFixture]
    public class UtilTests
    {
        [Test]
        public void NormalizeUrl_GetCleanUrl_ReturnUrl()
        {
            //arrange
            String url = "https://sandbox.api.mastercard.com/mastercom/v1/queuesqueue-name=Closed&Format=JSON";
            //act
            var result = Util.NormalizeUrl(url);
            //assert
            String expectedUrl = "https://sandbox.api.mastercard.com/mastercom/v1/queuesqueue-name=Closed&Format=JSON";
            Assert.AreEqual(url, expectedUrl);
        }

        [Test]
        public void NormalizeParameters_UrlHasQueryStringWithInputParameter_OnlyQueryStringParameters()
        {
            //arrange
            String queryString = "Format=JSON&Test=1";
            String url = "https://sandbox.api.mastercard.com/mastercom/v1/queuesqueue-name=Closed?" + queryString;
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            parameters.Add("Test2", "2");
            queryString += "&Test2=2";
            //act
            var result = Util.NormalizeParameters(url, parameters);
            //assert
            Assert.AreEqual(result, queryString);
        }

        [Test]
        public void NormalizeParameters_UrlHasQueryStringWithInputParameter_WithoutQueryStringParameters()
        {
            //arrange 
            String url = "https://sandbox.api.mastercard.com/mastercom/v1/queuesqueue-name=Closed";
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            parameters.Add("Test2", "2");
            //act
            var result = Util.NormalizeParameters(url, parameters);
            //assert
            Assert.AreEqual(result, "Test2=2");
        }

        [Test]
        [TestCase("test!test", "test%21test")]
        [TestCase("test*test", "test%2Atest")]
        [TestCase("test\\test", "test%5Ctest")]
        [TestCase("test(test", "test%28test")]
        [TestCase("test)test", "test%29test")]
        public void UriRfc3986_ReplaceUriRfc_Replace(String inputString, String outputString)
        {
            //act
            var result = Util.UriRfc3986(inputString);
            //assert
            Assert.That(result, Is.EqualTo(outputString));
        }

        [Test]
        public void Sha256Encode_ComputeHash_ReturnSha256Encode()
        {
            String test = "teststring";
            var result = Util.Sha256Encode(test);
            Assert.That(result.Length, Is.EqualTo(32));
        }

        [Test]
        public void Base64Encode_String_ReturnBase64String()
        {
            Byte[] data = { 65, 66, 67, 68 };
            var result = Util.Base64Encode(data);
            Assert.AreEqual(result, "QUJDRA==");
        }

    }
}
