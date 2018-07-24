// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.Constants
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using System.Collections.Generic;

namespace MasterCard.Core.Model
{
  public class Constants
  {
    public static readonly Dictionary<Constants.Environment, List<string>> MAPPINGS;

    static Constants()
    {
      Dictionary<Constants.Environment, List<string>> dictionary = new Dictionary<Constants.Environment, List<string>>();
      int num1 = 0;
      dictionary.Add((Constants.Environment) num1, new List<string>()
      {
        "https://api.mastercard.com",
        (string) null
      });
      int num2 = 1;
      dictionary.Add((Constants.Environment) num2, new List<string>()
      {
        "https://sandbox.api.mastercard.com",
        (string) null
      });
      int num3 = 2;
      dictionary.Add((Constants.Environment) num3, new List<string>()
      {
        "https://sandbox.api.mastercard.com",
        "static"
      });
      int num4 = 3;
      dictionary.Add((Constants.Environment) num4, new List<string>()
      {
        "https://sandbox.api.mastercard.com",
        "mft"
      });
      int num5 = 4;
      dictionary.Add((Constants.Environment) num5, new List<string>()
      {
        "https://sandbox.api.mastercard.com",
        "itf"
      });
      int num6 = 5;
      dictionary.Add((Constants.Environment) num6, new List<string>()
      {
        "https://stage.api.mastercard.com",
        (string) null
      });
      int num7 = 6;
      dictionary.Add((Constants.Environment) num7, new List<string>()
      {
        "https://dev.api.mastercard.com",
        (string) null
      });
      int num8 = 7;
      dictionary.Add((Constants.Environment) num8, new List<string>()
      {
        "https://api.mastercard.com",
        "mtf"
      });
      int num9 = 8;
      dictionary.Add((Constants.Environment) num9, new List<string>()
      {
        "https://api.mastercard.com",
        "itf"
      });
      int num10 = 9;
      dictionary.Add((Constants.Environment) num10, new List<string>()
      {
        "https://stage.api.mastercard.com",
        "mtf"
      });
      int num11 = 10;
      dictionary.Add((Constants.Environment) num11, new List<string>()
      {
        "https://stage.api.mastercard.com",
        "itf"
      });
      int num12 = 11;
      dictionary.Add((Constants.Environment) num12, new List<string>()
      {
        "http://localhost:8081",
        (string) null
      });
      Constants.MAPPINGS = dictionary;
    }

    public enum Environment
    {
      PRODUCTION,
      SANDBOX,
      SANDBOX_STATIC,
      SANDBOX_MTF,
      SANDBOX_ITF,
      STAGE,
      DEV,
      PRODUCTION_MTF,
      PRODUCTION_ITF,
      STAGE_MTF,
      STAGE_ITF,
      LOCALHOST,
      OTHER,
    }
  }
}
