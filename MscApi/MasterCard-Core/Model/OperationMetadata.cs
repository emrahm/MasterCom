// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.OperationMetadata
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

namespace MasterCard.Core.Model
{
    public class OperationMetadata
    {
        public string Host;

        public string Context;

        public string Version;

        public OperationMetadata(string version, string host)
        {
            // ISSUE: reference to a compiler-generated field
            Version = version;
            // ISSUE: reference to a compiler-generated field
            Host = host;
        }

        public OperationMetadata(string version, string host, string context)
        {
            // ISSUE: reference to a compiler-generated field
            Version = version;
            // ISSUE: reference to a compiler-generated field
            Host = host;
            // ISSUE: reference to a compiler-generated field
            Version = context;
        }
    }
}
