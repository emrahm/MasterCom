using Clearing.Msc.Business.MasterCom.Tqr4;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.UnitTest.Tqr4
{
    [TestFixture]
    public class Tqr4FileParserTests
    {
        Mock<ITqr4FileReader> iTqr4FileReaderMock = new Mock<ITqr4FileReader>();

        [SetUp]
        public void SetUp()
        {
            String line = @"9061807030000001906600006000000020000000200002281842000000030000233572890000250970518706416500000005599712405105710101" +
                           "0000000100000002052700000000007588                        840      8402                    5542DYNATOKFL      TEST 182" +
                           "96155 TXN1    1804211200000000000918600000009870SUCCESS                                                               " +
                           "                                                                                                                      " +
                           "                                                                                                                      " +
                           "                                                                                                                      " +
                           "                                                                                               R";
            List<String> lines = new List<string>();
            lines.Add(line);
            iTqr4FileReaderMock.Setup(f => f.GetFileLines()).Returns(lines.ToArray());
        }

        [Test]
        public void GetParseData_GetParseData_ControlData()
        {
            //act
            Tqr4FileParser tqr4FileParser = new Tqr4FileParser(iTqr4FileReaderMock.Object);
            var result = tqr4FileParser.GetParseData();
            //assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].P0105, Is.EqualTo("9061807030000001906600006")); //  PDS 0105	n-25	File ID 	
            Assert.That(result[0].F071, Is.EqualTo("00000002"));				   	   // DE 71 		n-8 	Message Number	
            Assert.That(result[0].ClaimId, Is.EqualTo("0000000200002281842"));	   //    NA			n-19 	Claim ID
            Assert.That(result[0].EventId, Is.EqualTo("0000000300002335728"));     //    NA			n-19 	Event ID
            Assert.That(result[0].F095, Is.EqualTo("9000025097"));				   // DE 95		n-10 	Cycle ID
            Assert.That(result[0].F031, Is.EqualTo("05187064165000000055997"));	   //    DE 31 		n-23 	Acquirer Reference Number
            Assert.That(result[0].Mtid, Is.EqualTo("1240"));					   // MTI			n-4 	Mti
            Assert.That(result[0].F002, Is.EqualTo("5105710101000000010"));		   //    DE 2		n-19 	Pan
            Assert.That(result[0].F003, Is.EqualTo("000000")); 					   //    DE 3    	n-6 	Processing Code
            Assert.That(result[0].F024, Is.EqualTo("205"));						   //    DE 24		n-3 	Function Code
            Assert.That(result[0].F025, Is.EqualTo("2700"));					   // DE 25		n-4 	Message Reason Code
            Assert.That(result[0].F004, Is.EqualTo("000000007588"));			   // DE 4		n-12 	Amount Transaction
            Assert.That(result[0].F005, Is.EqualTo("            "));				   // DE 5		n-12 	Amount Reconciliation
            Assert.That(result[0].F006, Is.EqualTo("            "));				   // DE 6     	n-12 	Amount Cardholder Billing	Amount
            Assert.That(result[0].F049, Is.EqualTo("840"));						   //    DE 49		n-3 	Transaction Currency Code
            Assert.That(result[0].F050, Is.EqualTo("   "));				   // DE 50		n-3 	Reconciliation Currency Code
            Assert.That(result[0].F051, Is.EqualTo("   "));				   // DE 51		n-3 	Cardholder Billing Currency code
            Assert.That(result[0].P0148, Is.EqualTo("8402        "));        			   // DE148	    N-12	(n4-n4-n4)Currency code and exponent 
            Assert.That(result[0].F037, Is.EqualTo("            "));		   // DE 37		ans-12	Retrieval Reference Number
            Assert.That(result[0].F026, Is.EqualTo("5542"));					   // DE 26    	n-4		Mcc
            Assert.That(result[0].F042, Is.EqualTo("DYNATOKFL      "));      			   //    DE 42	    ans-15	Card Acceptor ID
            Assert.That(result[0].F043, Is.EqualTo("TEST 18296155 TXN1    "));    	   // DE 43       ans-22	Card Acceptor Name
            Assert.That(result[0].F012, Is.EqualTo("180421120000"));			   // DE 12		n-12	Date & Time of Transaction
            Assert.That(result[0].F094, Is.EqualTo("00000009186"));				   //    DE 94		n-11	Transaction Originator Institution ID Code
            Assert.That(result[0].F093, Is.EqualTo("00000009870"));				   //    DE 93		n-11	Transaction Destination Institution ID Code
            Assert.That(result[0].Status, Is.EqualTo("SUCCESS"));                  //  NA			a-7		Transaction Status                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            Assert.That(result[0].RejectReason.Length, Is.EqualTo(512));			   // th	NA1		ans-512	Reason for Rejection
            Assert.That(result[0].P0025, Is.EqualTo("R"));						   // PDS 0025 	a-1		Reversal Flag
        }
    }
}
