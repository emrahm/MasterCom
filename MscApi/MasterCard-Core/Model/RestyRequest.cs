// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.RestyRequest
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using MasterCard.Core.Security;
using RestSharp;
using System;

namespace MasterCard.Core.Model
{
  internal class RestyRequest : RestRequest
  {
    public Uri AbsoluteUrl { get; set; }

    public Uri BaseUrl { get; set; }

    public CryptographyInterceptor interceptor { get; set; }

    public RestyRequest(Uri url, Method method)
      : base(url, method)
    {
    }
  }
}
