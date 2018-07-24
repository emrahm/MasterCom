// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.RequestMap
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using System.Collections.Generic;

namespace MasterCard.Core.Model
{
  public class RequestMap : SmartMap
  {
    public RequestMap(bool caseInsensitive = false)
      : base(caseInsensitive)
    {
    }

    public RequestMap(RequestMap bm)
      : base((SmartMap) bm)
    {
    }

    public RequestMap(IDictionary<string, object> map, bool caseInsensitive = false)
      : base(map, caseInsensitive)
    {
    }

    public RequestMap(string jsonMapString, bool caseInsensitive = false)
      : base(jsonMapString, caseInsensitive)
    {
    }

    public RequestMap(string key, object value)
      : base(key, value)
    {
    }
  }
}
