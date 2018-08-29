using System;
using System.Collections.Generic;

namespace Clearing.Msc.Business.MasterCom.Tqr4
{
    public interface ITqr4FileParser
    {
        List<Tqr4FileFieldData> GetParseData();
    }
}
