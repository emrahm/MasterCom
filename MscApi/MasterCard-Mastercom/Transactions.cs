// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.Transactions
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
  public class Transactions : BaseObject
  {
    private static readonly Dictionary<string, OperationConfig> _store = new Dictionary<string, OperationConfig>()
    {
      {
        "a33972b0-8a47-4733-9c9f-6091faf2e7cf",
        new OperationConfig("/mastercom/v1/claims/{claim-id}/transactions/clearing/{transaction-id}", "read", new List<string>(), new List<string>())
      },
      {
        "078d9506-8a9e-44f5-9ce3-6cb4e09faf9a",
        new OperationConfig("/mastercom/v1/claims/{claim-id}/transactions/authorization/{transaction-id}", "read", new List<string>(), new List<string>())
      },
      {
        "ce71e3c9-2d7f-43e9-9fcf-2cebd00d53a3",
        new OperationConfig("/mastercom/v1/transactions/search", "create", new List<string>(), new List<string>())
      }
    };

    public Transactions(RequestMap bm)
      : base(bm)
    {
    }

    public Transactions()
    {
    }

    protected override OperationConfig GetOperationConfig(string operationUUID)
    {
      if (!Transactions._store.ContainsKey(operationUUID))
        throw new ArgumentException("Invalid operationUUID supplied: " + operationUUID);
      return Transactions._store[operationUUID];
    }

    protected override OperationMetadata GetOperationMetadata()
    {
      return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
    }

    public static Transactions retrieveClearingDetail(string id, RequestMap parameters = null)
    {
      RequestMap bm = new RequestMap(false);
      bm.Set("id", (object) id);
      if (parameters != null && parameters.Count > 0)
        bm.AddAll((IDictionary<string, object>) parameters);
      return BaseObject.Execute<Transactions>("a33972b0-8a47-4733-9c9f-6091faf2e7cf", new Transactions(bm));
    }

    public static Transactions retrieveAuthorizationDetail(string id, RequestMap parameters = null)
    {
      RequestMap bm = new RequestMap(false);
      bm.Set("id", (object) id);
      if (parameters != null && parameters.Count > 0)
        bm.AddAll((IDictionary<string, object>) parameters);
      return BaseObject.Execute<Transactions>("078d9506-8a9e-44f5-9ce3-6cb4e09faf9a", new Transactions(bm));
    }

    public static Transactions searchForTransaction(RequestMap map)
    {
      return BaseObject.Execute<Transactions>("ce71e3c9-2d7f-43e9-9fcf-2cebd00d53a3", new Transactions(map));
    }
  }
}
