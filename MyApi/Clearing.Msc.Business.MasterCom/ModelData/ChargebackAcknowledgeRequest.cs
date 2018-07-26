using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class ChargebackAcknowledgeRequest
    {
        public List<ChargebackRequest> chargebackList { get; set; }
    }
}
