// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.Claims
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
  public class Claims : BaseObject
  {
    private static readonly Dictionary<string, OperationConfig> _store = new Dictionary<string, OperationConfig>()
    {
      {
        "ef06f702-89ca-40db-b741-f349f210e0f5",
        new OperationConfig("/mastercom/v1/claims", "create", new List<string>(), new List<string>())
      },
      {
        "4ef30690-f8d4-4f05-82a4-254d56478605",
        new OperationConfig("/mastercom/v1/claims/{claim-id}", "read", new List<string>(), new List<string>())
      },
      {
        "fd2b938f-04f3-4c09-9bac-736136e38708",
        new OperationConfig("/mastercom/v1/claims/{claim-id}", "update", new List<string>(), new List<string>())
      }
    };

    public Claims(RequestMap bm)
      : base(bm)
    {
    }

    public Claims()
    {
    }

    protected override OperationConfig GetOperationConfig(string operationUUID)
    {
      if (!Claims._store.ContainsKey(operationUUID))
        throw new ArgumentException("Invalid operationUUID supplied: " + operationUUID);
      return Claims._store[operationUUID];
    }

    protected override OperationMetadata GetOperationMetadata()
    {
      return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
    }

    public static Claims create(RequestMap map)
    {
      return BaseObject.Execute<Claims>("ef06f702-89ca-40db-b741-f349f210e0f5", new Claims(map));
    }

    public static Claims retrieve(string id, RequestMap parameters = null)
    {
      RequestMap bm = new RequestMap(false);
      bm.Set("id", (object) id);
      if (parameters != null && parameters.Count > 0)
        bm.AddAll((IDictionary<string, object>) parameters);
      return BaseObject.Execute<Claims>("4ef30690-f8d4-4f05-82a4-254d56478605", new Claims(bm));
    }

    public Claims update()
    {
      return BaseObject.Execute<Claims>("fd2b938f-04f3-4c09-9bac-736136e38708", this);
    }
  }
}
