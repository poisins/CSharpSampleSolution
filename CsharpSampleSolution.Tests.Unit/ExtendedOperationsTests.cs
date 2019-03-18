namespace CsharpSampleSolution.Tests.Unit
{
    using CsharpSampleSolution.Common;
    using CsharpSampleSolution.Common.Business;
    using CsharpSampleSolution.Common.Business.Interfaces;
    using CsharpSampleSolution.Common.Enums;
    using CsharpSampleSolution.Tests.Data;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedOperationsTests
    {
        private readonly IExtendedOperations extendedOperations;

        public ExtendedOperationsTests()
        {
            this.extendedOperations = new ExtendedOperations();
        }

        #region Response should match

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Factorial))]
        public decimal DoOperations_Factorial_Correct(IOperationObject opObj)
        {
            return this.extendedOperations.DoOperation(opObj, OperationsEnum.Factorial);
        }

        [Test]
        [ExpectedException(typeof(NonIntegerException))]
        public void Factorial_Thorws_NonIntegerException()
        {
            Assert.AreNotEqual(10, this.extendedOperations.Factorial(new OperationObject<float, double>(5.5f, 0)));
        }

        #endregion

        #region Response should not match

        [Test]
        public void Factorial_InCorrect()
        {
            Assert.AreNotEqual(10, this.extendedOperations.Factorial(new OperationObject<int, double>(5, 0)));
        }

        #endregion

    }
}
