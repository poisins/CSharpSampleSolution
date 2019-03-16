namespace CsharpSampleSolution.Common.Business
{
    using CsharpSampleSolution.Common.Business.Interfaces;
    using CsharpSampleSolution.Common.Enums;
    using CsharpSampleSolution.Common.Helpers;

    public class ExtendedOperations : BasicOperations, IExtendedOperations
    {
        public override decimal DoOperation(decimal a, decimal b, OperationsEnum operation)
        {
            switch (operation)
            {
                case OperationsEnum.Factorial:
                    return this.Factorial(a);
            }

            return base.DoOperation(a, b, operation);
        }

        public int Factorial(IOperationObject opObj)
        {
            NullCheck(opObj, nameof(opObj));
            return this.Factorial(opObj.A);
        }

        public int Factorial(int a) => this.Factorial((decimal)a);

        private int Factorial(decimal d)
        {
            if (!NumberHelper.IsInteger(d))
            {
                throw new NonIntegerException();
            }

            int number = decimal.ToInt32(d);

            if (number <= 0)
            {
                return 1;
            }

            return number * this.Factorial(number - 1);
        }
    }
}
