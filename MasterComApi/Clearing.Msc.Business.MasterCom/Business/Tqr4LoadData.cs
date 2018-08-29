using Clearing.Msc.Business.MasterCom.DbObjects;
using Clearing.Msc.Business.MasterCom.Repository;
using Clearing.Msc.Business.MasterCom.Tqr4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Business
{
    public class Tqr4LoadData
    {
        ITqr4FileParser _iTqr4FileParser;
        ITransactionRepository _iTransactionRepository;

        public Tqr4LoadData(ITqr4FileParser iTqr4FileParser,
                            ITransactionRepository iTransactionRepository)
        {
            _iTqr4FileParser = iTqr4FileParser;
            _iTransactionRepository = iTransactionRepository;
        }

        public void LoadData()
        {
            List<MscMcomTqr4> mscMcomTqr4List = new List<MscMcomTqr4>();
            foreach (var item in _iTqr4FileParser.GetParseData())
            {
                var mscMcomTqr4 = GetMscMcomTqr4(item);
                MatchMcomTqr4(mscMcomTqr4);
                mscMcomTqr4List.Add(mscMcomTqr4);
            }
            _iTransactionRepository.InsertTqr4Data(mscMcomTqr4List);
        }

        private void MatchMcomTqr4(MscMcomTqr4 mscMcomTqr4)
        {
            mscMcomTqr4.ClrNo = 0;
        }

        private MscMcomTqr4 GetMscMcomTqr4(Tqr4FileFieldData item)
        {
            var mscMcomTqr4 = new MscMcomTqr4();
            mscMcomTqr4.P0105 = item.P0105;
            mscMcomTqr4.F071 = item.F071;
            mscMcomTqr4.ClaimId = item.ClaimId;
            mscMcomTqr4.EventId = item.EventId;
            mscMcomTqr4.F095 = item.F095;
            mscMcomTqr4.F031 = item.F031;
            mscMcomTqr4.Mtid = item.Mtid;
            mscMcomTqr4.F002 = item.F002;
            mscMcomTqr4.F003 = item.F003;
            mscMcomTqr4.F024 = item.F024;
            mscMcomTqr4.F025 = item.F025;
            if (!String.IsNullOrWhiteSpace(item.F004))
                mscMcomTqr4.F004 = Convert.ToDecimal(item.F004) / 100;
            if (!String.IsNullOrWhiteSpace(item.F005))
                mscMcomTqr4.F005 = Convert.ToDecimal(item.F005) / 100;
            if (!String.IsNullOrWhiteSpace(item.F006))
                mscMcomTqr4.F006 = Convert.ToDecimal(item.F006) / 100;
            mscMcomTqr4.F049 = item.F049;
            mscMcomTqr4.F050 = item.F050;
            mscMcomTqr4.F051 = item.F051;
            mscMcomTqr4.P0148 = item.P0148;
            mscMcomTqr4.F037 = item.F037;
            mscMcomTqr4.F026 = item.F026;
            mscMcomTqr4.F042 = item.F042;
            mscMcomTqr4.F043 = item.F043;
            mscMcomTqr4.F012S1 = item.F012.Substring(0, 6);
            mscMcomTqr4.F012S2 = item.F012.Substring(6, 6);
            mscMcomTqr4.F094 = item.F094;
            mscMcomTqr4.F093 = item.F093;
            mscMcomTqr4.RejectStatus = item.Status;
            mscMcomTqr4.RejectReason = item.RejectReason;
            mscMcomTqr4.P0025 = item.P0025;
            mscMcomTqr4.IncomingDate = DateTime.Now;
            mscMcomTqr4.InsertDateTime = DateTime.Now;
            return mscMcomTqr4;
        }
    }
}
