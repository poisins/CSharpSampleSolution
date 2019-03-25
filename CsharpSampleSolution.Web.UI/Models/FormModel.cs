namespace CsharpSampleSolution.Web.UI.Models
{
    using CsharpSampleSolution.Common.Enums;
    using CsharpSampleSolution.Common.Requests;

    public class FormModel
    {
        public CalculateRequest Input { get; set; }

        public OperationsEnum OperationType { get; set; }
    }
}
