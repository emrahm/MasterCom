using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class ResponseError
    {
        public string Source { get; set; }
        public string ReasonCode { get; set; }
        public string Description { get; set; }
        public bool Recoverable { get; set; }
        public string Details { get; set; }
    }

    public class Errors
    {
        public List<ResponseError> Error { get; set; }
    }

    public class ResponseErrorContent
    {
        public Errors Errors { get; set; }
    }


    public class Detail
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ServiceError
    {
        public string Source { get; set; }
        public string ReasonCode { get; set; }
        public string Description { get; set; }
        public bool Recoverable { get; set; }
        public List<Detail> Details { get; set; }
    }

    public class ResponseErrorDetail
    {
        public List<ServiceError> Errors { get; set; }
    }
}


