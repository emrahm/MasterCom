// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Security.CryptUtil
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MasterCard.Core.Security
{
    public static class CryptUtil
    {
        public static string SanitizeJson(string payload)
        {
            return payload.Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace(" ", "");
        }

        public static byte[] HexDecode(string hex)
        {
            return Enumerable.Range(0, hex.Length).Where<int>((Func<int, bool>)(x => x % 2 == 0)).Select<int, byte>((Func<int, byte>)(x => Convert.ToByte(hex.Substring(x, 2), 16))).ToArray<byte>();
        }

        public static string HexEncode(string hex)
        {
            return CryptUtil.HexEncode(Encoding.UTF8.GetBytes(hex));
        }

        public static string HexEncode(byte[] hexArray)
        {
            return BitConverter.ToString(hexArray).Replace("-", "");
        }

        public static Tuple<byte[], byte[], byte[]> EncryptAES(byte[] toEncrypt)
        {
            byte[] buffer = toEncrypt;
            using (AesCryptoServiceProvider cryptoServiceProvider1 = new AesCryptoServiceProvider())
            {
                cryptoServiceProvider1.KeySize = 256;
                cryptoServiceProvider1.GenerateKey();
                cryptoServiceProvider1.GenerateIV();
                cryptoServiceProvider1.Mode = CipherMode.CBC;
                cryptoServiceProvider1.Padding = PaddingMode.PKCS7;
                AesCryptoServiceProvider cryptoServiceProvider2 = cryptoServiceProvider1;
                byte[] key = cryptoServiceProvider2.Key;
                byte[] iv = cryptoServiceProvider1.IV;
                using (ICryptoTransform encryptor = cryptoServiceProvider2.CreateEncryptor(key, iv))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(buffer, 0, buffer.Length);
                            cryptoStream.FlushFinalBlock();
                        }
                        return new Tuple<byte[], byte[], byte[]>(cryptoServiceProvider1.IV, cryptoServiceProvider1.Key, memoryStream.ToArray());
                    }
                }
            }
        }

        public static byte[] DecryptAES(byte[] iv, byte[] encryptionKey, byte[] encryptedData)
        {
            using (AesCryptoServiceProvider cryptoServiceProvider1 = new AesCryptoServiceProvider())
            {
                cryptoServiceProvider1.KeySize = 256;
                cryptoServiceProvider1.IV = iv;
                cryptoServiceProvider1.Key = encryptionKey;
                cryptoServiceProvider1.Mode = CipherMode.CBC;
                cryptoServiceProvider1.Padding = PaddingMode.PKCS7;
                using (MemoryStream memoryStream1 = new MemoryStream(encryptedData))
                {
                    AesCryptoServiceProvider cryptoServiceProvider2 = cryptoServiceProvider1;
                    byte[] key = cryptoServiceProvider2.Key;
                    byte[] iv1 = cryptoServiceProvider1.IV;
                    using (ICryptoTransform decryptor = cryptoServiceProvider2.CreateDecryptor(key, iv1))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream1, decryptor, CryptoStreamMode.Read))
                        {
                            MemoryStream memoryStream2 = new MemoryStream();
                            byte[] buffer = new byte[1024];
                            int count;
                            while ((count = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                                memoryStream2.Write(buffer, 0, count);
                            return memoryStream2.ToArray();
                        }
                    }
                }
            }
        }

        public static RSACryptoServiceProvider GetRSAFromPrivateKeyString(string privateKey)
        {
            if (!privateKey.Contains("-----BEGIN RSA PRIVATE KEY-----"))
                throw new Exception("Error loading private key, key is not a private key");
            byte[] buffer = Convert.FromBase64String(privateKey.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "").Replace(Environment.NewLine, ""));
            RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
            RSAParameters parameters = new RSAParameters();
            using (BinaryReader binr = new BinaryReader((Stream)new MemoryStream(buffer)))
            {
                switch (binr.ReadUInt16())
                {
                    case 33072:
                        int num1 = (int)binr.ReadByte();
                        break;
                    case 33328:
                        int num2 = (int)binr.ReadInt16();
                        break;
                    default:
                        throw new Exception("Unexpected value read binr.ReadUInt16()");
                }
                if ((int)binr.ReadUInt16() != 258)
                    throw new Exception("Unexpected version");
                if ((int)binr.ReadByte() != 0)
                    throw new Exception("Unexpected value read binr.ReadByte()");
                parameters.Modulus = binr.ReadBytes(CryptUtil.GetIntegerSize(binr));
                parameters.Exponent = binr.ReadBytes(CryptUtil.GetIntegerSize(binr));
                parameters.D = binr.ReadBytes(CryptUtil.GetIntegerSize(binr));
                parameters.P = binr.ReadBytes(CryptUtil.GetIntegerSize(binr));
                parameters.Q = binr.ReadBytes(CryptUtil.GetIntegerSize(binr));
                parameters.DP = binr.ReadBytes(CryptUtil.GetIntegerSize(binr));
                parameters.DQ = binr.ReadBytes(CryptUtil.GetIntegerSize(binr));
                parameters.InverseQ = binr.ReadBytes(CryptUtil.GetIntegerSize(binr));
            }
            cryptoServiceProvider.ImportParameters(parameters);
            return cryptoServiceProvider;
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            if ((int)binr.ReadByte() != 2)
                return 0;
            byte num1 = binr.ReadByte();
            int num2;
            switch (num1)
            {
                case 129:
                    num2 = (int)binr.ReadByte();
                    break;
                case 130:
                    byte num3 = binr.ReadByte();
                    num2 = BitConverter.ToInt32(new byte[4]
          {
            binr.ReadByte(),
            num3,
            (byte) 0,
            (byte) 0
          }, 0);
                    break;
                default:
                    num2 = (int)num1;
                    break;
            }
            while ((int)binr.ReadByte() == 0)
                --num2;
            binr.BaseStream.Seek(-1L, SeekOrigin.Current);
            return num2;
        }

        public static byte[] EncrytptRSA(byte[] data, RSA publicKey)
        {
            using (RSA rsa = publicKey)
                return rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
        }

        public static byte[] DecryptRSA(byte[] data, RSA privateKey)
        {
            using (RSA rsa = privateKey)
                return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
        }
    }
}
