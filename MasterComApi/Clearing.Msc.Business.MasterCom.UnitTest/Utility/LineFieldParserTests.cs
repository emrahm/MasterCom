using Clearing.Msc.Business.MasterCom.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Utility
{
    [TestFixture]
    public class LineFieldParserTests
    {
        public class FieldData
        {
            public String Field1 = "";
            public String Field2 = "";
        }

        public class FieldDataWrongField
        {
            public String Field1 = "";
            public String Field3 = "";
        }


        public class FieldLen
        {
            public const int Field1 = 2;
            public const int Field2 = 3;
        }

        [Test]
        public void GetObject_ParseLine_GetObject()
        {
            //act
            var LineFieldParser = new LineFieldParser<FieldLen, FieldData>();
            FieldData fieldData = LineFieldParser.GetObject("12345");
            //assert
            Assert.That(fieldData.Field1, Is.EqualTo("12"));
            Assert.That(fieldData.Field2, Is.EqualTo("345"));
        }

        [Test]
        public void GetObject_WrongFieldName_GetException()
        {
            //arrange

            //act
            LineFieldParser<FieldLen, FieldDataWrongField> LineFieldParser = null;
            //assert
            Assert.That(() => { LineFieldParser = new LineFieldParser<FieldLen, FieldDataWrongField>(); }, Throws.InstanceOf<KeyNotFoundException>());
        }

        [Test]
        public void GetObject_LineLenghtNotEqual_GetException()
        {
            //arrange

            //act
            var LineFieldParser = new LineFieldParser<FieldLen, FieldData>();
            FieldData fieldData = LineFieldParser.GetObject("12345");
            //assert
            Assert.That(() => { LineFieldParser.GetObject("1234"); }, Throws.InstanceOf<IndexOutOfRangeException>());
        }
    }
}
