using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.DbObjects
{
    public class MscMcomRequest
    {
        public Int64 Guid { get; set; }
        public Int16 Status { get; set; }
        public Int64 LastUpdated { get; set; }
        public Int64 RefKey { get; set; }
        public String Url { get; set; }
        public String Request { get; set; }
        public String Response { get; set; }
        public short HttpStatus { get; set; }
    }
}
