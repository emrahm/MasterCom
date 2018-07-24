// Decompiled with JetBrains decompiler
// Type: MasterCard.Core.Model.OperationConfig
// Assembly: MasterCard-Core, Version=1.4.0.26200, Culture=neutral, PublicKeyToken=null
// MVID: FBF9ACCE-839B-46D3-83A0-494225AC75CB
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Core.1.4.0\lib\MasterCard-Core.dll

using System.Collections.Generic;

namespace MasterCard.Core.Model
{
    public class OperationConfig
    {
        public string ResourcePath;

        public string Action;

        public List<string> QueryParams;

        public List<string> HeaderParams;

        public OperationConfig(string resourcePath, string action, List<string> queryParams, List<string> headerParams)
        {
            // ISSUE: reference to a compiler-generated field
            ResourcePath = resourcePath;
            // ISSUE: reference to a compiler-generated field
            Action = action;
            // ISSUE: reference to a compiler-generated field
            QueryParams = queryParams;
            // ISSUE: reference to a compiler-generated field
            HeaderParams = headerParams;
        }
    }
}
