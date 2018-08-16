using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Tqr4
{
    public class Tqr4FileReader : ITqr4FileReader
    {
        String _filePath = "";

        public Tqr4FileReader(String filePath)
        {
            _filePath = filePath;
        }

        public String[] GetFileLines()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
