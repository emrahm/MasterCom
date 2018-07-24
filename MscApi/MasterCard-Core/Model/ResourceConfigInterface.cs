// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.ResourceConfigInterface
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

namespace MasterCard.Core.Model
{
  public interface ResourceConfigInterface
  {
    void SetEnvironment(Constants.Environment environment);

    void SetEnvironment(string host, string context);
  }
}
