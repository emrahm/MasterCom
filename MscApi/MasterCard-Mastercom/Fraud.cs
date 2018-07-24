// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.Fraud
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
  public class Fraud : BaseObject
  {
    private static readonly Dictionary<string, OperationConfig> _store = new Dictionary<string, OperationConfig>()
    {
      {
        "11236663-1e9c-4de4-916d-7a2a0bc61f26",
        new OperationConfig("/mastercom/v1/claims/{claim-id}/fraud/mastercard", "create", new List<string>(), new List<string>())
      },
      {
        "95c57dab-f305-4281-86ec-a7650415dc05",
        new OperationConfig("/mastercom/v1/claims/{claim-id}/fraud/loaddataforfraud", "query", new List<string>(), new List<string>())
      }
    };

    public Fraud(RequestMap bm)
      : base(bm)
    {
    }

    public Fraud()
    {
    }

    protected override OperationConfig GetOperationConfig(string operationUUID)
    {
      if (!Fraud._store.ContainsKey(operationUUID))
        throw new ArgumentException("Invalid operationUUID supplied: " + operationUUID);
      return Fraud._store[operationUUID];
    }

    protected override OperationMetadata GetOperationMetadata()
    {
      return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
    }

    public static Fraud createForMasterCard(RequestMap map)
    {
      return BaseObject.Execute<Fraud>("11236663-1e9c-4de4-916d-7a2a0bc61f26", new Fraud(map));
    }

    public static Fraud getPossibleValueListsForCreate(RequestMap parameters)
    {
      return BaseObject.Execute<Fraud>("95c57dab-f305-4281-86ec-a7650415dc05", new Fraud(parameters));
    }
  }
}
