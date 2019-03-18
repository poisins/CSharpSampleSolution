namespace CsharpSampleSolution.Common.Extensions
{
    using CsharpSampleSolution.Common.Requests;

    public static class OperationObjectExtensions
    {
        public static OperationObject<decimal, decimal> FromCalculateRequest(this CalculateRequest req)
        {
            return new OperationObject<decimal, decimal>(req.A, req.B);
        }
    }
}
