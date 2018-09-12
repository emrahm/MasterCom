using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Utility
{
    public class ApiConstants
    {
        public class PoolActionType
        {
            public const String Chargeback = "CB";
            public const String ChargebackReversal = "CBRV";
            public const String Queues = "QUE";
            public const String ChargebackDocument = "CBDOC";
            public const String ResponseStatusUpdate = "RSU";
            public const string CaseFilling = "CFLL";
            public const string Retrieval = "RRVL";
        }

        public class ChargebackStatus
        {
            public const String Chargeback = "CHARGEBACK";
            public const String SecondChargeback = "SECOND_PRESENTMENT";
            public const String ArbChargeback = "ARB_CHARGEBACK";
        }

        public class ChargebackResponseStatus
        {
            public const String Completed = "COMPLETED";
            public const String Failed = "FAILED";
            public const String Pending = "PENDING";
            public const String UnAvailable = "UNAVAILABLE";
        }
    }
}
