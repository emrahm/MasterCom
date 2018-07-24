// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.Retrievals
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
  public class Retrievals : BaseObject
  {
    private static readonly Dictionary<string, OperationConfig> _store;

    static Retrievals()
    {
      Dictionary<string, OperationConfig> dictionary = new Dictionary<string, OperationConfig>();
      dictionary.Add("2f8bd1e6-06e1-470c-b023-4e3c4a9c789a", new OperationConfig("/mastercom/v1/claims/{claim-id}/retrievalrequests/{request-id}/fulfillments", "create", new List<string>(), new List<string>()));
      dictionary.Add("1357d418-805b-4a2e-9c15-4024e86e9724", new OperationConfig("/mastercom/v1/claims/{claim-id}/retrievalrequests", "create", new List<string>(), new List<string>()));
      dictionary.Add("f68fa419-abbe-421b-b925-4eb0ccb953e0", new OperationConfig("/mastercom/v1/claims/{claim-id}/retrievalrequests/loaddataforretrievalrequests", "query", new List<string>(), new List<string>()));
      string key1 = "f5eae873-8f5c-4c82-a442-d998d9175b89";
      string resourcePath = "/mastercom/v1/claims/{claim-id}/retrievalrequests/{request-id}/documents";
      string action = "query";
      List<string> queryParams = new List<string>();
      queryParams.Add("format");
      List<string> headerParams = new List<string>();
      OperationConfig operationConfig1 = new OperationConfig(resourcePath, action, queryParams, headerParams);
      dictionary.Add(key1, operationConfig1);
      string key2 = "4a905638-f62b-4693-b0d2-9d8912edf566";
      OperationConfig operationConfig2 = new OperationConfig("/mastercom/v1/claims/{claim-id}/retrievalrequests/{request-id}/fulfillments/response", "create", new List<string>(), new List<string>());
      dictionary.Add(key2, operationConfig2);
      string key3 = "92687603-fb06-4b96-9a0a-a51e1f377395";
      OperationConfig operationConfig3 = new OperationConfig("/mastercom/v1/retrievalrequests/status", "update", new List<string>(), new List<string>());
      dictionary.Add(key3, operationConfig3);
      Retrievals._store = dictionary;
    }

    public Retrievals(RequestMap bm)
      : base(bm)
    {
    }

    public Retrievals()
    {
    }

    protected override OperationConfig GetOperationConfig(string operationUUID)
    {
      if (!Retrievals._store.ContainsKey(operationUUID))
        throw new ArgumentException("Invalid operationUUID supplied: " + operationUUID);
      return Retrievals._store[operationUUID];
    }

    protected override OperationMetadata GetOperationMetadata()
    {
      return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
    }

    public static Retrievals acquirerFulfillARequest(RequestMap map)
    {
      return BaseObject.Execute<Retrievals>("2f8bd1e6-06e1-470c-b023-4e3c4a9c789a", new Retrievals(map));
    }

    public static Retrievals create(RequestMap map)
    {
      return BaseObject.Execute<Retrievals>("1357d418-805b-4a2e-9c15-4024e86e9724", new Retrievals(map));
    }

    public static Retrievals getPossibleValueListsForCreate(RequestMap parameters)
    {
      return BaseObject.Execute<Retrievals>("f68fa419-abbe-421b-b925-4eb0ccb953e0", new Retrievals(parameters));
    }

    public static Retrievals getDocumentation(RequestMap parameters)
    {
      return BaseObject.Execute<Retrievals>("f5eae873-8f5c-4c82-a442-d998d9175b89", new Retrievals(parameters));
    }

    public static Retrievals issuerRespondToFulfillment(RequestMap map)
    {
      return BaseObject.Execute<Retrievals>("4a905638-f62b-4693-b0d2-9d8912edf566", new Retrievals(map));
    }

    public Retrievals retrievalFullfilmentStatus()
    {
      return BaseObject.Execute<Retrievals>("92687603-fb06-4b96-9a0a-a51e1f377395", this);
    }
  }
}
