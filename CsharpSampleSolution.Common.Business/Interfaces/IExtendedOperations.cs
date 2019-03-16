namespace CsharpSampleSolution.Common.Business.Interfaces
{
    public interface IExtendedOperations : IBasicOperations
    {
        /// <summary>
        /// Calculates Factorial of the provided integer
        /// </summary>
        /// <param name="opObj">Only <seealso cref="IOperationObject.A"/> value will be used</param>
        int Factorial(IOperationObject opObj);

        /// <summary>
        /// Calculates Factorial of the provided integer
        /// </summary>
        int Factorial(int a);
    }
}
