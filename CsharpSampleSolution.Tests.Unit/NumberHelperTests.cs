namespace CsharpSampleSolution.Tests.Unit
{
    using CsharpSampleSolution.Common.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class NumberHelperTests
    {
        [TestCase(12f, true)]
        [TestCase(0f, true)]
        [TestCase(4.5f, false)]
        [TestCase(4.485f, false)]
        public void IsInteger_Float_Correct(float f, bool isInteger)
        {
            Assert.AreEqual(isInteger, NumberHelper.IsInteger(f));
        }

        [Test]
        public void IsInteger_Decimal_Correct()
        {
            Assert.AreEqual(true, NumberHelper.IsInteger(12m));
            Assert.AreEqual(true, NumberHelper.IsInteger(0m));
            Assert.AreEqual(false, NumberHelper.IsInteger(4.5m));
            Assert.AreEqual(false, NumberHelper.IsInteger(4.485m));
        }

        [TestCase(12d, true)]
        [TestCase(0d, true)]
        [TestCase(4.5d, false)]
        [TestCase(4.485d, false)]
        public void IsInteger_Double_Correct(double d, bool isInteger)
        {
            Assert.AreEqual(isInteger, NumberHelper.IsInteger(d));
        }
    }
}