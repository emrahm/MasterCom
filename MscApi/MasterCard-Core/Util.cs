// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Util
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MasterCard.Core
{
  public static class Util
  {
    private static readonly string[] URIRFC3986CHARSTOESCAPE = new string[5]
    {
      "!",
      "*",
      "'",
      "(",
      ")"
    };
    private static UTF8Encoding encoder = new UTF8Encoding();

    public static string NormalizeUrl(string requestUrl)
    {
      Uri uri = new Uri(requestUrl);
      return string.Format("{0}{1}{2}{3}", new object[4]
      {
        (object) uri.Scheme,
        (object) Uri.SchemeDelimiter,
        (object) uri.Authority,
        (object) uri.AbsolutePath
      });
    }

    public static string GetCurrenyAssemblyPath()
    {
      return Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Remove(0, "file:\\".Length);
    }

    public static IDictionary<string, object> SubMap(IDictionary<string, object> inputMap, List<string> inList)
    {
      IDictionary<string, object> dictionary = (IDictionary<string, object>) new Dictionary<string, object>();
      foreach (string @in in inList)
      {
        if (inputMap.ContainsKey(@in))
        {
          dictionary.Add(@in, inputMap[@in]);
          inputMap.Remove(@in);
        }
      }
      return dictionary;
    }

    public static string GetReplacedPath(string path, IDictionary<string, object> inputMap)
    {
      string str = (string) path.Clone();
      foreach (Match match in Regex.Matches(path, "{(.*?)}"))
      {
        string key = match.Groups[1].Value;
        if (!inputMap.ContainsKey(key))
          throw new ArgumentException("Error, path paramer: '" + key + "' expected but not found in input map");
        object obj = (object) "";
        inputMap.TryGetValue(key, out obj);
        str = str.Replace("{" + key + "}", obj.ToString());
        inputMap.Remove(key);
      }
      return str;
    }

    public static string NormalizeParameters(string requestUrl, SortedDictionary<string, string> oauthParameters)
    {
      StringBuilder stringBuilder = new StringBuilder();
      SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>((IDictionary<string, string>) oauthParameters, (IComparer<string>) StringComparer.Ordinal);
      if (requestUrl.IndexOf('?') > 0)
      {
        string str1 = requestUrl;
        int num = 63;
        int startIndex = str1.IndexOf((char) num);
        NameValueCollection queryString = HttpUtility.ParseQueryString(str1.Substring(startIndex));
        foreach (string str2 in (NameObjectCollectionBase) queryString)
        {
          foreach (string str3 in queryString.GetValues(str2))
            sortedDictionary.Add(str2, str3);
        }
      }
      foreach (KeyValuePair<string, string> keyValuePair in sortedDictionary)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append("&");
        stringBuilder.Append(Util.UriRfc3986(keyValuePair.Key)).Append("=").Append(Util.UriRfc3986(keyValuePair.Value));
      }
      return stringBuilder.ToString();
    }

    public static string UriRfc3986(string stringToEncode)
    {
      StringBuilder stringBuilder = new StringBuilder(Uri.EscapeDataString(stringToEncode));
      for (int index = 0; index < Util.URIRFC3986CHARSTOESCAPE.Length; ++index)
        stringBuilder.Replace(Util.URIRFC3986CHARSTOESCAPE[index], Uri.HexEscape(Util.URIRFC3986CHARSTOESCAPE[index][0]));
      return stringBuilder.ToString();
    }

    public static byte[] Sha1Encode(string input)
    {
      return new SHA1CryptoServiceProvider().ComputeHash(Util.encoder.GetBytes(input));
    }

    public static byte[] Sha256Encode(string input)
    {
      return new SHA256CryptoServiceProvider().ComputeHash(Util.encoder.GetBytes(input));
    }

    public static string Base64Encode(byte[] textBytes)
    {
      return Convert.ToBase64String(textBytes);
    }
  }
}
