// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Security.OAuth.OAuthUtil
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MasterCard.Core.Security.OAuth
{
  internal static class OAuthUtil
  {
    private static Random random = new Random();
    private static readonly string VALID_CHAR = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private static string GetNonce()
    {
      int num = 17;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < num; ++index)
        stringBuilder.Append(OAuthUtil.VALID_CHAR[OAuthUtil.random.Next(0, OAuthUtil.VALID_CHAR.Length - 1)]);
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

    public static string GetBaseString(string requestUrl, string httpMethod, SortedDictionary<string, string> oauthParameters)
    {
      return Util.UriRfc3986(httpMethod.ToUpper()) + "&" + Util.UriRfc3986(Util.NormalizeUrl(requestUrl)) + "&" + Util.UriRfc3986(Util.NormalizeParameters(requestUrl, oauthParameters));
    }

    public static string RsaSign(string baseString)
    {
      return ApiConfig.GetAuthentication().SignMessage(baseString);
    }

    public static string GenerateSignature(string URL, string method, string body, string clientId, AsymmetricAlgorithm privateKey)
    {
      OAuthParameters oauthParameters = new OAuthParameters();
      oauthParameters.setOAuthConsumerKey(clientId);
      oauthParameters.setOAuthNonce(OAuthUtil.GetNonce());
      oauthParameters.setOAuthTimestamp(OAuthUtil.GetTimestamp());
      oauthParameters.setOAuthSignatureMethod("RSA-SHA256");
      oauthParameters.setOAuthVersion("1.0");
      if (!string.IsNullOrEmpty(body))
      {
        string bodyHash = Util.Base64Encode(Util.Sha256Encode(body));
        oauthParameters.setOAuthBodyHash(bodyHash);
      }
      string signature = OAuthUtil.RsaSign(OAuthUtil.GetBaseString(URL, method, oauthParameters.getBaseParameters()));
      oauthParameters.setOAuthSignature(signature);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<string, string> baseParameter in oauthParameters.getBaseParameters())
      {
        if (stringBuilder.Length == 0)
          stringBuilder.Append(OAuthParameters.OAUTH_KEY).Append(" ");
        else
          stringBuilder.Append(",");
        stringBuilder.Append(baseParameter.Key).Append("=\"").Append(Util.UriRfc3986(baseParameter.Value)).Append("\"");
      }
      return stringBuilder.ToString();
    }
  }
}
