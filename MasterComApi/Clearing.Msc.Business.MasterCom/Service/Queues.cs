﻿using Clearing.Msc.Business.MasterCom.ModelData;
using Clearing.Msc.Business.MasterCom.Security;
using Clearing.Msc.Business.MasterCom.Utility;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Model
{
    /*
     "/mastercom/v1/queues", "list"  queue-name
     "/mastercom/v1/queues/names", "list" 
     */
    public class Queues : IQueues 
    {
        IApiController _apiController = null;
        public Queues(IApiController apiController)
        {
            _apiController = apiController;
        }

        public List<ResponseQueue> GetQueues(long refKey, String queueName)
        {
            if (String.IsNullOrWhiteSpace(queueName))
                throw new Exception("QueueName can not be null or empty");

            Dictionary<String, String> parameters = new Dictionary<string,string>();
            parameters.Add("queue-name", queueName);
            return _apiController.Get<List<ResponseQueue>>(refKey, "queues", parameters); 
        }
    }
}
