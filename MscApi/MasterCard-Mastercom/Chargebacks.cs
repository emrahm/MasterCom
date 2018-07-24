// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.Chargebacks
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
  public class Chargebacks : BaseObject
  {
    private static readonly Dictionary<string, OperationConfig> _store;

    static Chargebacks()
    {
      Dictionary<string, OperationConfig> dictionary = new Dictionary<string, OperationConfig>();
      dictionary.Add("6268dea6-913d-495f-8e19-aa2b49aad2e1", new OperationConfig("/mastercom/v1/chargebacks/acknowledge", "update", new List<string>(), new List<string>()));
      dictionary.Add("c4ecc518-b6f0-4136-88af-ecd97f391fad", new OperationConfig("/mastercom/v1/claims/{claim-id}/chargebacks", "create", new List<string>(), new List<string>()));
      dictionary.Add("06564b96-58de-4f92-903c-3149bc9643f5", new OperationConfig("/mastercom/v1/claims/{claim-id}/chargebacks/{chargeback-id}/reversal", "create", new List<string>(), new List<string>()));
      string key1 = "44df475c-5dee-43d8-8b45-3b9f7d87ac81";
      string resourcePath = "/mastercom/v1/claims/{claim-id}/chargebacks/{chargeback-id}/documents";
      string action = "query";
      List<string> queryParams = new List<string>();
      queryParams.Add("format");
      List<string> headerParams = new List<string>();
      OperationConfig operationConfig1 = new OperationConfig(resourcePath, action, queryParams, headerParams);
      dictionary.Add(key1, operationConfig1);
      string key2 = "d25506ed-78f9-47b8-9e85-aaaddb80da3c";
      OperationConfig operationConfig2 = new OperationConfig("/mastercom/v1/claims/{claim-id}/chargebacks/loaddataforchargebacks", "query", new List<string>(), new List<string>());
      dictionary.Add(key2, operationConfig2);
      string key3 = "83710749-183b-4e36-9c72-b8c1cab458e1";
      OperationConfig operationConfig3 = new OperationConfig("/mastercom/v1/chargebacks/status", "update", new List<string>(), new List<string>());
      dictionary.Add(key3, operationConfig3);
      string key4 = "6e0dd74e-b0ac-47a0-b886-823297bc95df";
      OperationConfig operationConfig4 = new OperationConfig("/mastercom/v1/claims/{claim-id}/chargebacks/{chargeback-id}", "update", new List<string>(), new List<string>());
      dictionary.Add(key4, operationConfig4);
      Chargebacks._store = dictionary;
    }

    public Chargebacks(RequestMap bm)
      : base(bm)
    {
    }

    public Chargebacks()
    {
    }

    protected override OperationConfig GetOperationConfig(string operationUUID)
    {
      if (!Chargebacks._store.ContainsKey(operationUUID))
        throw new ArgumentException("Invalid operationUUID supplied: " + operationUUID);
      return Chargebacks._store[operationUUID];
    }

    protected override OperationMetadata GetOperationMetadata()
    {
      return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
    }

    public Chargebacks acknowledgeReceivedChargebacks()
    {
      return BaseObject.Execute<Chargebacks>("6268dea6-913d-495f-8e19-aa2b49aad2e1", this);
    }

    public static Chargebacks create(RequestMap map)
    {
      return BaseObject.Execute<Chargebacks>("c4ecc518-b6f0-4136-88af-ecd97f391fad", new Chargebacks(map));
    }

    public static Chargebacks createReversal(RequestMap map)
    {
      return BaseObject.Execute<Chargebacks>("06564b96-58de-4f92-903c-3149bc9643f5", new Chargebacks(map));
    }

    public static Chargebacks retrieveDocumentation(RequestMap parameters)
    {
      return BaseObject.Execute<Chargebacks>("44df475c-5dee-43d8-8b45-3b9f7d87ac81", new Chargebacks(parameters));
    }

    public static Chargebacks getPossibleValueListsForCreate(RequestMap parameters)
    {
      return BaseObject.Execute<Chargebacks>("d25506ed-78f9-47b8-9e85-aaaddb80da3c", new Chargebacks(parameters));
    }

    public Chargebacks chargebacksStatus()
    {
      return BaseObject.Execute<Chargebacks>("83710749-183b-4e36-9c72-b8c1cab458e1", this);
    }

    public Chargebacks update()
    {
      return BaseObject.Execute<Chargebacks>("6e0dd74e-b0ac-47a0-b886-823297bc95df", this);
    }
  }
}
