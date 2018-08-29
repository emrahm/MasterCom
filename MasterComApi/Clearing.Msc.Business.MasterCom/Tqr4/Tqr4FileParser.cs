using Clearing.Msc.Business.MasterCom.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Tqr4
{
    public class Tqr4FileParser : Clearing.Msc.Business.MasterCom.Tqr4.ITqr4FileParser
    {
        ITqr4FileReader _iTqr4FileReader = null;

        public Tqr4FileParser(ITqr4FileReader iTqr4FileReader)
	    {
            _iTqr4FileReader = iTqr4FileReader;
	    }

        public List<Tqr4FileFieldData> GetParseData()
        {
            var lineFieldParcer = new LineFieldParser<Tqr4FileFieldLen, Tqr4FileFieldData>();
            var tqr4FileFieldDataList = new List<Tqr4FileFieldData>();
            foreach (var item in _iTqr4FileReader.GetFileLines())
            {
                Tqr4FileFieldData tqr4FileFieldData = lineFieldParcer.GetObject(item);
                tqr4FileFieldDataList.Add(tqr4FileFieldData);
            } 
            return tqr4FileFieldDataList;
        } 
    }
}
