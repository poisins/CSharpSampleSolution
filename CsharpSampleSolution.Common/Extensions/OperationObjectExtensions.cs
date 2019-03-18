namespace CsharpSampleSolution.Common.Extensions
{
    using CsharpSampleSolution.Common.Requests;

    public static class OperationObjectExtensions
    {
        public static IOperationObject FromCalculateRequest(this CalculateRequest req)
        {
            return new OperationObject<decimal, decimal>(req.A, req.B);
        }

        public static CalculateRequest ToCalculateRequest(this IOperationObject opObj)
        {
            return new CalculateRequest
            {
                A = opObj.A,
                B = opObj.B,
            };
        }
    }
}
