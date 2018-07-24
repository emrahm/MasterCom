// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.Fees
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
  public class Fees : BaseObject
  {
    private static readonly Dictionary<string, OperationConfig> _store = new Dictionary<string, OperationConfig>()
    {
      {
        "87b1c226-0740-4b0e-8e95-ea8c30304ecc",
        new OperationConfig("/mastercom/v1/claims/{claim-id}/fee", "create", new List<string>(), new List<string>())
      },
      {
        "6d456a8d-4e49-4e9b-bed0-75233c57f0cc",
        new OperationConfig("/mastercom/v1/claims/{claim-id}/fees/loaddataforfees", "query", new List<string>(), new List<string>())
      }
    };

    public Fees(RequestMap bm)
      : base(bm)
    {
    }

    public Fees()
    {
    }

    protected override OperationConfig GetOperationConfig(string operationUUID)
    {
      if (!Fees._store.ContainsKey(operationUUID))
        throw new ArgumentException("Invalid operationUUID supplied: " + operationUUID);
      return Fees._store[operationUUID];
    }

    protected override OperationMetadata GetOperationMetadata()
    {
      return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
    }

    public static Fees create(RequestMap map)
    {
      return BaseObject.Execute<Fees>("87b1c226-0740-4b0e-8e95-ea8c30304ecc", new Fees(map));
    }

    public static Fees getPossibleValueListsForCreate(RequestMap parameters)
    {
      return BaseObject.Execute<Fees>("6d456a8d-4e49-4e9b-bed0-75233c57f0cc", new Fees(parameters));
    }
  }
}
