using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtension
    {
        public static Dictionary<string, string> ToDictionary(this String[][] value)
        {
            if (value == null)
                return null;
            Dictionary<String, String> dic = new Dictionary<string, string>();
            for (int i = 0; i < value.Length; i++)
            {
                dic.Add(value[i][0], value[i][1]);
            }
            return dic;
        }
    }
}
