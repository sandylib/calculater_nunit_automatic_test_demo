using System;
using System.Collections.Generic;
using System.IO;
using MathProblems.PaySlip;
using NUnit.Framework;

using NSubstitute;

namespace MathProblems.Tests.PaySlip
{
    [TestFixture, Category("PaySlipCalculator")]
    public class PaySlipConvertorTest
    {
        private PaySlipCalculator _paySlipCalculator;
        private IResultFormatter _resultFormatter;


        [SetUp]
        public void Initialize()
        {
            _paySlipCalculator = new PaySlipCalculator();
            _resultFormatter = new TextFileFormatter();
        }

        [Test]
        [Category("PaySlips")]
        public void ReadAndConvert()
        {
            PaySlipCalculator mokPaySlipCalculator = Substitute.For<PaySlipCalculator>();
            IResultFormatter mokIResultFormatter = Substitute.For<IResultFormatter>();
             mokIResultFormatter.ReadConvert(Arg.Any<string>()).Returns(new List<string> { "David,Rudd,60050,9%,01 March - 31 March", "Ryan,Chen,120000,10%,01 March - 31 March" });
            var expect = new List<string> { "David Rudd,01 March - 31 March,5004,922,4082,450", "Ryan Chen,01 March - 31 March,10000,2696,7304,1000" };

            var sut =  mokPaySlipCalculator.Convert(mokIResultFormatter.ReadConvert(""));

            Assert.AreEqual(sut[0], expect[0]);
            Assert.AreEqual(sut[1], expect[1]);
        }

        [Test]
        [Category("PaySlips")]
        public void ShouldConvert()
        {
            var input =  new List<string> { "David,Rudd,60050,9%,01 March - 31 March", "Ryan,Chen,120000,10%,01 March - 31 March" };
            var expect = new List<string> { "David Rudd,01 March - 31 March,5004,922,4082,450", "Ryan Chen,01 March - 31 March,10000,2696,7304,1000" };

            var sut = _paySlipCalculator.Convert(input);

            Assert.AreEqual(sut[0], expect[0]);
            Assert.AreEqual(sut[1], expect[1]);
        }


        [Test]
        [Category("PaySlips")]
        public void OutPutCSVFileTest()
        {

            var input = new List<string> { "David,Rudd,60050,9%,01 March - 31 March", "Ryan,Chen,120000,10%,01 March - 31 March" };
            var expect = new List<string> { "David Rudd,01 March - 31 March,5004,922,4082,450", "Ryan Chen,01 March - 31 March,10000,2696,7304,1000" };

            var sut = _paySlipCalculator.Convert(input);

            _resultFormatter.Format(sut);

        }

       

        [Test]
        [Category("PaySlips")]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Annual salary can not be negative number ")]
        public void PositiveDigiterTestShouldThrow()
        {
            var input = new List<string> { "David,Rudd,-1258,9%,01 March - 31 March", "Ryan,Chen,120000,10%,01 March - 31 March" };
             var sut = _paySlipCalculator.Convert(input);
           

        }

        [Test]
        [Category("PaySlips")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DateTimeRangerValidatorTest1()
        {
            var input = new List<string> { "David,Rudd,75000,9%, - ", "Ryan,Chen,120000,10%,01 March - 31 March" };
           
                var sut = _paySlipCalculator.Convert(input);
            

        }

        [Test]
        [Category("PaySlips")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateTimeRangerValidatorTest2()
        {
            var input = new List<string> { "David,Rudd,522222,9%,01 March - 01 March" };
            var sut = _paySlipCalculator.Convert(input);
        }

    }
}
