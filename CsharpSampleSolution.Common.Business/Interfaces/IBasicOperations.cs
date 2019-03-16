namespace CsharpSampleSolution.Common.Business.Interfaces
{
    using CsharpSampleSolution.Common.Enums;

    public interface IBasicOperations
    {
        decimal DoOperation(IOperationObject opObj, OperationsEnum operation);

        decimal DoOperation(decimal a, decimal b, OperationsEnum operation);

        decimal Add(IOperationObject opObj);

        decimal Add(decimal a, decimal b);

        decimal Subtract(IOperationObject opObj);

        decimal Subtract(decimal a, decimal b);

        decimal Multiply(IOperationObject opObj);

        decimal Multiply(decimal a, decimal b);

        decimal Divide(IOperationObject opObj);

        decimal Divide(decimal a, decimal b);
    }
}
