// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.ResourceList`1
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using System;
using System.Collections.Generic;

namespace MasterCard.Core.Model
{
  public class ResourceList<T> : List<T> where T : BaseObject
  {
    public ResourceList(IDictionary<string, object> map)
    {
      if (!map.ContainsKey("list") || !(typeof (List<Dictionary<string, object>>) == map["list"].GetType()))
        return;
      List<Dictionary<string, object>> dictionaryList = (List<Dictionary<string, object>>) map["list"];
      Type type = this.GetType().GetGenericArguments()[0];
      foreach (Dictionary<string, object> dictionary in dictionaryList)
      {
        T obj = (T) Activator.CreateInstance(type);
        obj.AddAll((IDictionary<string, object>) dictionary);
        this.Add(obj);
      }
    }
  }
}
