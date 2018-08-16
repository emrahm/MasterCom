using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.Utility
{
    public class LineFieldParser<TLenData, TFieldData>
    {
        List<int> _fieldInfo = null;
        List<FieldInfo> _fieldInfoList = null;
        int totalLenght = 0;

        public LineFieldParser()
        {
            SetFieldInfo();
        }

        public TFieldData GetObject(String line)
        {
            if (line.Length != totalLenght)
                throw new IndexOutOfRangeException("Line lenght is not equal to totalLen");

            TFieldData tFieldData = (TFieldData)Activator.CreateInstance<TFieldData>();
            int position = 0;
            for (int i = 0; i < _fieldInfo.Count; i++)
            {
                String value = line.Substring(position, _fieldInfo[i]);
                _fieldInfoList[i].SetValue(tFieldData, value);
                position += _fieldInfo[i];
            }
            return tFieldData;
        }

        private void SetFieldInfo()
        {
            _fieldInfo = new List<int>();
            _fieldInfoList = new List<FieldInfo>();
            TLenData tLenData = (TLenData)Activator.CreateInstance<TLenData>();
            Type fieldDataType = typeof(TFieldData);
            foreach (var item in tLenData.GetType().GetFields())
            {
                _fieldInfoList.Add(GetFieldInfo(fieldDataType, item.Name));
                int len = Convert.ToInt32(item.GetValue(tLenData));
                _fieldInfo.Add(len);
                totalLenght += len;
            }
        }

        private FieldInfo GetFieldInfo(Type fieldDataType, String fieldName)
        {
            FieldInfo fieldInfo = fieldDataType.GetField(fieldName);
            if (fieldInfo == null)
                throw new KeyNotFoundException(fieldName + " field name not found data definition object");
            return fieldInfo;
        }

    }
}
