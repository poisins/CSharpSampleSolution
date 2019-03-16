namespace CsharpSampleSolution.Common.Business
{
    using System;
    using CsharpSampleSolution.Common.Business.Interfaces;
    using CsharpSampleSolution.Common.Enums;

    public class BasicOperations : IBasicOperations
    {
        public virtual decimal DoOperation(IOperationObject opObj, OperationsEnum operation)
        {
            NullCheck(opObj, nameof(opObj));
            return this.DoOperation(opObj.A, opObj.B, operation);
        }

        public virtual decimal DoOperation(decimal a, decimal b, OperationsEnum operation)
        {
            switch (operation)
            {
                case OperationsEnum.Add:
                    return this.Add(a, b);
                case OperationsEnum.Subtract:
                    return this.Subtract(a, b);
                case OperationsEnum.Multiply:
                    return this.Multiply(a, b);
                case OperationsEnum.Divide:
                    return this.Divide(a, b);
                default:
                    throw new NotImplementedException($"Operation '{operation.ToString()}' is not implemented");
            }
        }

        public decimal Add(IOperationObject opObj)
        {
            NullCheck(opObj, nameof(opObj));
            return this.Add(opObj.A, opObj.B);
        }

        public decimal Add(decimal a, decimal b) => a + b;

        public decimal Subtract(IOperationObject opObj)
        {
            NullCheck(opObj, nameof(opObj));
            return this.Subtract(opObj.A, opObj.B);
        }

        public decimal Subtract(decimal a, decimal b) => a - b;

        public decimal Multiply(IOperationObject opObj)
        {
            NullCheck(opObj, nameof(opObj));
            return this.Multiply(opObj.A, opObj.B);
        }

        public decimal Multiply(decimal a, decimal b) => a * b;

        public decimal Divide(IOperationObject opObj)
        {
            NullCheck(opObj, nameof(opObj));
            return this.Divide(opObj.A, opObj.B);
        }

        public decimal Divide(decimal a, decimal b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }

        protected static void NullCheck(IOperationObject opObj, string name)
        {
            if (opObj == null)
            {
                throw new NullReferenceException($"'{name}' should not be null!");
            }
        }
    }
}
