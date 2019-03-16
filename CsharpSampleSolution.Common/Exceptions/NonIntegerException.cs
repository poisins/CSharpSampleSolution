namespace CsharpSampleSolution.Common
{
    using System;

    public class NonIntegerException : Exception
    {
        public NonIntegerException()
            : this("Numeric value should be integer")
        {
        }

        public NonIntegerException(string message)
            : base(message)
        {
        }

        public NonIntegerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
