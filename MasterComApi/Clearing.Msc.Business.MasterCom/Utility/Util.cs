using RestSharp.Extensions.MonoHttp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Clearing.Msc.Business.MasterCom.Utility
{
    public static class Util
    {
        private static Char[] UriRrc3986CharsTeEscape = { '!', '*', '\'', '(', ')' };
        private static UTF8Encoding encoder = new UTF8Encoding();

        public static string NormalizeUrl(string requestUrl)
        {
            Uri uri = new Uri(requestUrl);
            return String.Format("{0}{1}{2}{3}", uri.Scheme, Uri.SchemeDelimiter, uri.Authority, uri.AbsolutePath);
        } 

        public static string NormalizeParameters(string requestUrl, Dictionary<string, string> oauthParameters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(oauthParameters, StringComparer.Ordinal);
            if (requestUrl.IndexOf('?') > 0)
            {
                int startIndex = requestUrl.IndexOf('?');
                NameValueCollection queryString = HttpUtility.ParseQueryString(requestUrl.Substring(startIndex));
                foreach (string str2 in (NameObjectCollectionBase)queryString)
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
            for (int index = 0; index < UriRrc3986CharsTeEscape.Length; ++index)
            {
                String rrc3986CharEscape = UriRrc3986CharsTeEscape[index].ToString();
                String hexEscape = Uri.HexEscape(UriRrc3986CharsTeEscape[index]);
                stringBuilder.Replace(rrc3986CharEscape, hexEscape);
            }
            return stringBuilder.ToString();
        } 

        public static byte[] Sha256Encode(string input)
        {
            return new SHA256CryptoServiceProvider().ComputeHash(encoder.GetBytes(input));
        }

        public static string Base64Encode(byte[] textBytes)
        {
            return Convert.ToBase64String(textBytes);
        }

        public static Uri GetUrl(String baseUrl,
                                 String urlVersion,
                                 String restUrl, 
                                 Dictionary<String, String> parameterQuery)
        {
            StringBuilder url = new StringBuilder();
            url.Append(baseUrl);
            url.Append(urlVersion);
            url.Append(restUrl);
            if (parameterQuery != null)
                foreach (var item in parameterQuery)
                    AppendToQueryString(url,
                                        String.Format("{0}={1}", item.Key, item.Value));
            return new Uri(url.ToString());
        }

        private static void AppendToQueryString(StringBuilder s, string stringToAppend)
        {
            if (s.ToString().IndexOf("?") == -1)
                s.Append("?");
            if (s.ToString().IndexOf("?") != s.Length - 1)
                s.Append("&");
            s.Append(stringToAppend);
        }
    }
}
