namespace CsharpSampleSolution.Tests.Data
{
    using System.Collections;
    using CsharpSampleSolution.Common;
    using NUnit.Framework;

    public static class OperationsTestData
    {
        #region Test Data

        public static IEnumerable Add
        {
            get
            {
                yield return new TestCaseData(new OperationObject<int, int>(0, 0)).Returns(0);
                yield return new TestCaseData(new OperationObject<int, int>(5, 0)).Returns(5);
                yield return new TestCaseData(new OperationObject<int, int>(0, 2)).Returns(2);
                yield return new TestCaseData(new OperationObject<int, int>(7, 2)).Returns(9);
                yield return new TestCaseData(new OperationObject<int, decimal>(10, 2.5m)).Returns(12.5m);
            }
        }

        public static IEnumerable Subtract
        {
            get
            {
                yield return new TestCaseData(new OperationObject<int, int>(0, 0)).Returns(0);
                yield return new TestCaseData(new OperationObject<int, int>(5, 0)).Returns(5);
                yield return new TestCaseData(new OperationObject<int, int>(0, 2)).Returns(-2);
                yield return new TestCaseData(new OperationObject<int, int>(7, 2)).Returns(5);
                yield return new TestCaseData(new OperationObject<int, decimal>(10, 2.5m)).Returns(7.5m);
            }
        }

        public static IEnumerable Multiply
        {
            get
            {
                yield return new TestCaseData(new OperationObject<int, int>(0, 0)).Returns(0);
                yield return new TestCaseData(new OperationObject<int, int>(5, 0)).Returns(0);
                yield return new TestCaseData(new OperationObject<int, int>(0, 2)).Returns(0);
                yield return new TestCaseData(new OperationObject<int, int>(7, 2)).Returns(14);
                yield return new TestCaseData(new OperationObject<int, decimal>(10, 2.5m)).Returns(25);
                yield return new TestCaseData(new OperationObject<float, float>(2.5f, 2.5f)).Returns(6.25f);
            }
        }

        public static IEnumerable Divide
        {
            get
            {
                yield return new TestCaseData(new OperationObject<int, int>(0, 1)).Returns(0);
                yield return new TestCaseData(new OperationObject<int, int>(0, 2)).Returns(0);
                yield return new TestCaseData(new OperationObject<int, int>(7, 2)).Returns(3.5f);
                yield return new TestCaseData(new OperationObject<int, decimal>(10, 2.5m)).Returns(4);
                yield return new TestCaseData(new OperationObject<float, float>(2.5f, 2.5f)).Returns(1);
            }
        }

        public static IEnumerable Factorial
        {
            get
            {
                yield return new TestCaseData(new OperationObject<int, int>(0, 1)).Returns(1);
                yield return new TestCaseData(new OperationObject<int, int>(7, 0)).Returns(5040);
                yield return new TestCaseData(new OperationObject<int, int>(4, 0)).Returns(24);
            }
        }
        #endregion
    }
}
