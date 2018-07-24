using Clearing.Msc.Business.MasterCom.Security;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Security
{
    [TestFixture]
    public class OAuthParametersTests
    {
        OAuthParameters authParameters = new OAuthParameters();
        String controlKey = "test";
        [Test]
        public void setOAuthConsumerKey_SetValueAndControl_getBaseParameters()
        {
            //act 
            authParameters.setOAuthConsumerKey(controlKey);
            //assert
            controlKeyValue(OAuthParameters.OAUTH_CONSUMER_KEY);
        }

        [Test]
        public void setOAuthNonce_SetValueAndControl_getBaseParameters()
        {
            //act 
            authParameters.setOAuthNonce(controlKey);
            //assert
            controlKeyValue(OAuthParameters.OAUTH_NONCE_KEY);
        }

        [Test]
        public void setOAuthTimestamp_SetValueAndControl_getBaseParameters()
        {
            //act 
            authParameters.setOAuthTimestamp(controlKey);
            //assert
            controlKeyValue(OAuthParameters.OAUTH_TIMESTAMP_KEY);
        }

        [Test]
        public void setOAuthSignature_SetValueAndControl_getBaseParameters()
        {
            //act 
            authParameters.setOAuthSignature(controlKey);
            //assert
            controlKeyValue(OAuthParameters.OAUTH_SIGNATURE_KEY);
        }

        [Test]
        public void setOAuthBodyHash_SetValueAndControl_getBaseParameters()
        {
            //act 
            authParameters.setOAuthBodyHash(controlKey);
            //assert
            controlKeyValue(OAuthParameters.OAUTH_BODY_HASH_KEY);
        }

        [Test]
        public void setOAuthVersion_SetValueAndControl_getBaseParameters()
        {
            //act 
            authParameters.setOAuthVersion(controlKey);
            //assert
            controlKeyValue(OAuthParameters.OAUTH_VERSION);
        }

        [Test]
        public void setOAuthSignatureMethod_SetValueAndControl_getBaseParameters()
        {
            //act 
            authParameters.setOAuthSignatureMethod(controlKey);
            //assert
            controlKeyValue(OAuthParameters.OAUTH_SIGNATURE_METHOD_KEY);
        }



        private void controlKeyValue(String parameterName)
        {
            Assert.That(() => authParameters.getBaseParameters().ContainsKey(parameterName), controlKey);
        }
    }
}
