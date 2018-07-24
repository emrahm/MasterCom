// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Security.MDES.MDESCryptography
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using MasterCard.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MasterCard.Core.Security.MDES
{
  public class MDESCryptography : CryptographyInterceptor
  {
    private List<string> fieldsToHide = new List<string>()
    {
      "publicKeyFingerprint",
      "oaepHashingAlgorithm",
      "iv",
      "encryptedData",
      "encryptedKey"
    };
    private string triggeringPath = "/mdes/tokenization/";
    private RSA publicKey;
    private string publicKeyFingerPrint;
    private RSA privateKey;

    public MDESCryptography(string publicKeyLocation, string privateKeyLocation)
    {
      X509Certificate2 certificate = new X509Certificate2(publicKeyLocation);
      this.publicKey = certificate.GetRSAPublicKey();
      this.publicKeyFingerPrint = certificate.Thumbprint;
      this.privateKey = (RSA) CryptUtil.GetRSAFromPrivateKeyString(File.ReadAllText(privateKeyLocation));
    }

    public string GetTriggeringPath()
    {
      return this.triggeringPath;
    }

    public IDictionary<string, object> Encrypt(IDictionary<string, object> map)
    {
      if (map.ContainsKey("cardInfo"))
      {
        Tuple<byte[], byte[], byte[]> tuple = CryptUtil.EncryptAES(Encoding.UTF8.GetBytes(CryptUtil.SanitizeJson(JsonConvert.SerializeObject((object) (IDictionary<string, object>) map["cardInfo"]))));
        byte[] hexArray1 = tuple.Item1;
        byte[] data = tuple.Item2;
        byte[] hexArray2 = tuple.Item3;
        string str1 = CryptUtil.HexEncode(hexArray1);
        string str2 = CryptUtil.HexEncode(hexArray2);
        string str3 = CryptUtil.HexEncode(CryptUtil.EncrytptRSA(data, this.publicKey));
        string str4 = this.publicKeyFingerPrint;
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        dictionary.Add("publicKeyFingerprint", (object) str4);
        dictionary.Add("encryptedKey", (object) str3);
        dictionary.Add("oaepHashingAlgorithm", (object) "SHA256");
        dictionary.Add("iv", (object) str1);
        dictionary.Add("encryptedData", (object) str2);
        map.Remove("cardInfo");
        map.Add("cardInfo", (object) dictionary);
      }
      return map;
    }

    public IDictionary<string, object> Decrypt(IDictionary<string, object> map)
    {
      if (map.ContainsKey("token"))
      {
        IDictionary<string, object> dictionary = (IDictionary<string, object>) map["token"];
        if (dictionary.ContainsKey("") && dictionary.ContainsKey(""))
        {
          byte[] numArray1 = CryptUtil.DecryptRSA(CryptUtil.HexDecode((string) dictionary["encryptedKey"]), this.privateKey);
          byte[] iv = CryptUtil.HexDecode((string) dictionary["iv"]);
          byte[] numArray2 = CryptUtil.HexDecode((string) dictionary["encryptedData"]);
          byte[] encryptionKey = numArray1;
          byte[] encryptedData = numArray2;
          string @string = Encoding.UTF8.GetString(CryptUtil.DecryptAES(iv, encryptionKey, encryptedData));
          foreach (string key in this.fieldsToHide)
            dictionary.Remove(key);
          foreach (KeyValuePair<string, object> @as in (Dictionary<string, object>) SmartMap.AsDictionary(@string))
            dictionary.Add(@as.Key, @as.Value);
        }
      }
      return map;
    }
  }
}
