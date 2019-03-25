namespace CsharpSampleSolution.Common.Requests
{
    using System.ComponentModel;

    public class CalculateRequest
    {
        [DisplayName("A")]
        public decimal A { get; set; }

        [DisplayName("B")]
        public decimal B { get; set; }
    }
}
