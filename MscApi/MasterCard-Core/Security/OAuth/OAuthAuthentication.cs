// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Security.OAuth.OAuthAuthentication
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using RestSharp;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MasterCard.Core.Security.OAuth
{
  public class OAuthAuthentication : AuthenticationInterface
  {
    private readonly AsymmetricAlgorithm privateKey;
    private readonly string clientId;
    private readonly UTF8Encoding encoder;
    private readonly X509Certificate2 cert;

    public AsymmetricAlgorithm PrivateKey
    {
      get
      {
        return this.privateKey;
      }
    }

    public string ClientId
    {
      get
      {
        return this.clientId;
      }
    }

    public OAuthAuthentication(string clientId, string filePath, string alias, string password)
    {
      this.cert = new X509Certificate2(filePath, password, X509KeyStorageFlags.Exportable);
      this.privateKey = this.cert.PrivateKey;
      this.clientId = clientId;
      this.encoder = new UTF8Encoding();
    }

    public void SignRequest(Uri uri, IRestRequest request)
    {
      string string1 = uri.ToString();
      string string2 = request.Method.ToString();
      string str = "";
      Parameter parameter = request.Parameters.FirstOrDefault<Parameter>((Func<Parameter, bool>) (p => p.Type == ParameterType.RequestBody));
      if (parameter != null)
        str = parameter.Value.ToString();
      string method = string2;
      string body = str;
      string clientId = this.clientId;
      AsymmetricAlgorithm privateKey = this.privateKey;
      string signature = OAuthUtil.GenerateSignature(string1, method, body, clientId, privateKey);
      request.AddHeader("Authorization", signature);
    }

    public string SignMessage(string message)
    {
      byte[] numArray = Util.Sha256Encode(message);
      RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
      string xmlString = this.cert.PrivateKey.ToXmlString(true);
      cryptoServiceProvider.FromXmlString(xmlString);
      byte[] rgbHash = numArray;
      string oid = CryptoConfig.MapNameToOID("SHA256");
      return Convert.ToBase64String(cryptoServiceProvider.SignHash(rgbHash, oid));
    }
  }
}
