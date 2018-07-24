// Decompiled with JetBrains decompiler
// Type: MasterCard.Api.Mastercom.Queues
// Assembly: MasterCard-Mastercom, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D794006-EF28-4DBF-97FC-7640E5AF009E
// Assembly location: D:\Sources\Mastercom\MasterComTest\packages\MasterCard-Mastercom.0.0.5\lib\MasterCard-Mastercom.dll

using MasterCard.Core.Model;
using System;
using System.Collections.Generic;

namespace MasterCard.Api.Mastercom
{
    public class Queues : BaseObject
    {
        private static readonly Dictionary<string, OperationConfig> _store;

        static Queues()
        {
            Dictionary<string, OperationConfig> dictionary = new Dictionary<string, OperationConfig>();
            string key1 = "81b4affd-48f1-4781-b6fb-624d95898013";
            string resourcePath = "/mastercom/v1/queues";
            string action = "list";
            List<string> queryParams = new List<string>();
            queryParams.Add("queue-name");
            List<string> headerParams = new List<string>();
            OperationConfig operationConfig1 = new OperationConfig(resourcePath, action, queryParams, headerParams);
            dictionary.Add(key1, operationConfig1);
            string key2 = "4cf17236-e9af-4029-b2f8-1e8674fe80ed";
            OperationConfig operationConfig2 = new OperationConfig("/mastercom/v1/queues/names", "list", new List<string>(), new List<string>());
            dictionary.Add(key2, operationConfig2);
            Queues._store = dictionary;
        }

        public Queues(RequestMap bm)
            : base(bm)
        {
        }

        public Queues()
        {
        }

        protected override OperationConfig GetOperationConfig(string operationUUID)
        {
            if (!Queues._store.ContainsKey(operationUUID))
                throw new ArgumentException("Invalid operationUUID supplied: " + operationUUID);
            return Queues._store[operationUUID];
        }

        //protected override OperationMetadata GetOperationMetadata()
        //{
        //    return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
        //}
        protected override OperationMetadata GetOperationMetadata()
        {
            return new OperationMetadata(ResourceConfig.Instance.GetVersion(), ResourceConfig.Instance.GetHost(), ResourceConfig.Instance.GetContext(), ResourceConfig.Instance.GetJsonNative(), ResourceConfig.Instance.GetContentTypeOverride());
        }

        public static List<Queues> retrieveClaimsFromQueue()
        {
            return (List<Queues>)BaseObject.ExecuteForList<Queues>("81b4affd-48f1-4781-b6fb-624d95898013", new Queues());
        }

        public static List<Queues> retrieveClaimsFromQueue(RequestMap criteria)
        {
            return (List<Queues>)BaseObject.ExecuteForList<Queues>("81b4affd-48f1-4781-b6fb-624d95898013", new Queues(criteria));
        }

        public static List<Queues> retrieveQueueNames()
        {
            return (List<Queues>)BaseObject.ExecuteForList<Queues>("4cf17236-e9af-4029-b2f8-1e8674fe80ed", new Queues());
        }

        public static List<Queues> retrieveQueueNames(RequestMap criteria)
        {
            return (List<Queues>)BaseObject.ExecuteForList<Queues>("4cf17236-e9af-4029-b2f8-1e8674fe80ed", new Queues(criteria));
        }

      
    }
}
