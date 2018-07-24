// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.CaseFiling
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
  public class CaseFiling : BaseObject
  {
    private static readonly Dictionary<string, OperationConfig> _store;

    static CaseFiling()
    {
      Dictionary<string, OperationConfig> dictionary = new Dictionary<string, OperationConfig>();
      dictionary.Add("f693cb99-0284-4616-9ee9-cd8a294b3835", new OperationConfig("/mastercom/v1/cases", "create", new List<string>(), new List<string>()));
      string key1 = "88e5d632-d255-4534-85a4-74d4b2bf9402";
      string resourcePath = "/mastercom/v1/cases/{case-id}/documents";
      string action = "query";
      List<string> queryParams = new List<string>();
      queryParams.Add("format");
      queryParams.Add("memo");
      List<string> headerParams = new List<string>();
      OperationConfig operationConfig1 = new OperationConfig(resourcePath, action, queryParams, headerParams);
      dictionary.Add(key1, operationConfig1);
      string key2 = "5abaf390-efca-4258-b195-de731862a758";
      OperationConfig operationConfig2 = new OperationConfig("/mastercom/v1/cases/status", "update", new List<string>(), new List<string>());
      dictionary.Add(key2, operationConfig2);
      string key3 = "33e7dff0-1ff1-4296-a892-ffad44a281bc";
      OperationConfig operationConfig3 = new OperationConfig("/mastercom/v1/cases/{case-id}", "update", new List<string>(), new List<string>());
      dictionary.Add(key3, operationConfig3);
      CaseFiling._store = dictionary;
    }

    public CaseFiling(RequestMap bm)
      : base(bm)
    {
    }

    public CaseFiling()
    {
    }

    protected override OperationConfig GetOperationConfig(string operationUUID)
    {
      if (!CaseFiling._store.ContainsKey(operationUUID))
        throw new ArgumentException("Invalid operationUUID supplied: " + operationUUID);
      return CaseFiling._store[operationUUID];
    }

    protected override OperationMetadata GetOperationMetadata()
    {
      return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
    }

    public static CaseFiling create(RequestMap map)
    {
      return BaseObject.Execute<CaseFiling>("f693cb99-0284-4616-9ee9-cd8a294b3835", new CaseFiling(map));
    }

    public static CaseFiling retrieveDocumentation(RequestMap parameters)
    {
      return BaseObject.Execute<CaseFiling>("88e5d632-d255-4534-85a4-74d4b2bf9402", new CaseFiling(parameters));
    }

    public CaseFiling caseFilingStatus()
    {
      return BaseObject.Execute<CaseFiling>("5abaf390-efca-4258-b195-de731862a758", this);
    }

    public CaseFiling update()
    {
      return BaseObject.Execute<CaseFiling>("33e7dff0-1ff1-4296-a892-ffad44a281bc", this);
    }
  }
}
