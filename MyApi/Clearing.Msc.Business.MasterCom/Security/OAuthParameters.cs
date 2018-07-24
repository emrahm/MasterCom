using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Security
{
    public class OAuthParameters
    {
        public static readonly string OAUTH_BODY_HASH_KEY = "oauth_body_hash";
        public static readonly string OAUTH_CALLBACK_KEY = "oauth_callback";
        public static readonly string OAUTH_CONSUMER_KEY = "oauth_consumer_key";
        public static readonly string OAUTH_CONSUMER_SECRET = "oauth_consumer_secret";
        public static readonly string OAUTH_NONCE_KEY = "oauth_nonce";
        public static readonly string OAUTH_KEY = "OAuth";
        public static readonly string OAUTH_SIGNATURE_KEY = "oauth_signature";
        public static readonly string OAUTH_SIGNATURE_METHOD_KEY = "oauth_signature_method";
        public static readonly string OAUTH_TIMESTAMP_KEY = "oauth_timestamp";
        public static readonly string OAUTH_TOKEN_KEY = "oauth_token";
        public static readonly string OAUTH_TOKEN_SECRET_KEY = "oauth_token_secret";
        public static readonly string OAUTH_VERIFIER_KEY = "oauth_verifier";
        public static readonly string OAUTH_VERSION = "oauth_version";
        public static readonly string REALM_KEY = "realm";
        public static readonly string XOAUTH_REQUESTOR_ID_KEY = "xoauth_requestor_id";

        protected Dictionary<string, string> baseParameters;

        public OAuthParameters()
        {
            baseParameters = new Dictionary<string, string>();
        }

        private void Put(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                baseParameters.Add(key, value);
        }

        public void setOAuthConsumerKey(string consumerKey)
        {
            Put(OAuthParameters.OAUTH_CONSUMER_KEY, consumerKey);
        }

        public void setOAuthNonce(string oauthNonce)
        {
            Put(OAuthParameters.OAUTH_NONCE_KEY, oauthNonce);
        }

        public void setOAuthTimestamp(string timestamp)
        {
            Put(OAuthParameters.OAUTH_TIMESTAMP_KEY, timestamp);
        }

        public void setOAuthSignatureMethod(string signatureMethod)
        {
            Put(OAuthParameters.OAUTH_SIGNATURE_METHOD_KEY, signatureMethod);
        }

        public void setOAuthSignature(string signature)
        {
            Put(OAuthParameters.OAUTH_SIGNATURE_KEY, signature);
        }

        public void setOAuthBodyHash(string bodyHash)
        {
            Put(OAuthParameters.OAUTH_BODY_HASH_KEY, bodyHash);
        }

        public void setOAuthVersion(string version)
        {
            Put(OAuthParameters.OAUTH_VERSION, version);
        }

        public Dictionary<string, string> getBaseParameters()
        {
            return baseParameters;
        }
    }
}
