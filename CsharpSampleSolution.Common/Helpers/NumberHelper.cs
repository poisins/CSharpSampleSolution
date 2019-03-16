namespace CsharpSampleSolution.Common.Helpers
{
    public static class NumberHelper
    {
        public static bool IsInteger(float f) => IsInteger((decimal)f);

        public static bool IsInteger(double d) => IsInteger((decimal)d);

        public static bool IsInteger(decimal d) => (d % 1) == 0;
    }
}
