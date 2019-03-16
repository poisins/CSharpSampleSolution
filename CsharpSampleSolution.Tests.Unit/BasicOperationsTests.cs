namespace CsharpSampleSolution.Tests.Unit
{
    using System;
    using CsharpSampleSolution.Common;
    using CsharpSampleSolution.Common.Business;
    using CsharpSampleSolution.Common.Business.Interfaces;
    using CsharpSampleSolution.Common.Enums;
    using CsharpSampleSolution.Tests.Unit.Data;
    using NUnit.Framework;

    [TestFixture]
    public class BasicOperationsTests
    {
        private readonly IBasicOperations basicOperations;

        public BasicOperationsTests()
        {
            this.basicOperations = new BasicOperations();
        }

        #region Response should match

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Add))]
        public decimal DoOperations_Add_Correct(IOperationObject opObj)
        {
            return this.basicOperations.DoOperation(opObj, OperationsEnum.Add);
        }

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Subtract))]
        public decimal DoOperations_Subtract_Correct(IOperationObject opObj)
        {
            return this.basicOperations.DoOperation(opObj, OperationsEnum.Subtract);
        }

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Multiply))]
        public decimal DoOperations_Multiply_Correct(IOperationObject opObj)
        {
            return this.basicOperations.DoOperation(opObj, OperationsEnum.Multiply);
        }

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Divide))]
        public decimal DoOperations_Divide_Correct(IOperationObject opObj)
        {
            return this.basicOperations.DoOperation(opObj, OperationsEnum.Divide);
        }

        #endregion

        #region Response should not match

        [Test]
        public void Add_InCorrect()
        {
            Assert.AreNotEqual(10, this.basicOperations.Add(new OperationObject<int, double>(5, 5.128d)));
        }

        [Test]
        public void Subtract_InCorrect()
        {
            Assert.AreNotEqual(0, this.basicOperations.Subtract(new OperationObject<int, double>(5, 5.128d)));
        }

        [Test]
        public void Divide_InCorrect()
        {
            Assert.AreNotEqual(1, this.basicOperations.Divide(new OperationObject<int, double>(5, 5.128d)));
        }

        [Test]
        public void Multiply_InCorrect()
        {
            Assert.AreNotEqual(25, this.basicOperations.Multiply(new OperationObject<int, double>(5, 5.128d)));
        }

        #endregion

        #region Exceptions

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_Throws_DivideByZeroException()
        {
            this.basicOperations.Divide(5, 0);
        }

        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void DoOperations_Factorial_Throws_NotImplementedException()
        {
            this.basicOperations.DoOperation(new OperationObject<int, double>(5, 0), OperationsEnum.Factorial);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void DoOperations_DoOperationCheck_Throws_NullReferenceException()
        {
            this.basicOperations.DoOperation(null, OperationsEnum.Add);
        }

        #endregion
    }
}
