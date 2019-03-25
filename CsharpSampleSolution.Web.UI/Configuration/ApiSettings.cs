namespace CsharpSampleSolution.Web.UI.Configuration
{
    using System.Collections.Generic;
    using CsharpSampleSolution.Common.Enums;

    public class ApiSettings
    {
        public string BaseUrl { get; set; }

        public Dictionary<OperationsEnum, string> Endpoints { get; set; }
    }
}
