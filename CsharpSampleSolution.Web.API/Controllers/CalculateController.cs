namespace CsharpSampleSolution.Web.API.Controllers
{
    using CsharpSampleSolution.Common.Business.Interfaces;
    using CsharpSampleSolution.Common.Enums;
    using CsharpSampleSolution.Common.Extensions;
    using CsharpSampleSolution.Common.Requests;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    // This will create API endpoint - http://localhost:55101/api/calculate
    [Route("api/[controller]")]
    public class CalculateController : Controller
    {
        private readonly IExtendedOperations extendedOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateController"/> class.
        /// </summary>
        /// <param name="extendedOperations">This Dependency is registered in <see cref="Startup.ConfigureServices(IServiceCollection)"/> and will be accessible for this class when needed</param>
        public CalculateController(IExtendedOperations extendedOperations)
        {
            this.extendedOperations = extendedOperations;
        }

        // This method will be called with endpoint: http://localhost:55101/api/calculate/add
        [HttpPost("add")]
        public IActionResult Add([FromBody] CalculateRequest req)
        {
            return this.Json(this.extendedOperations.DoOperation(req.FromCalculateRequest(), OperationsEnum.Add));
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] CalculateRequest req)
        {
            return this.Json(this.extendedOperations.DoOperation(req.FromCalculateRequest(), OperationsEnum.Subtract));
        }

        [HttpPost("multiply")]
        public IActionResult Multiply([FromBody] CalculateRequest req)
        {
            return this.Json(this.extendedOperations.DoOperation(req.FromCalculateRequest(), OperationsEnum.Multiply));
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] CalculateRequest req)
        {
            return this.Json(this.extendedOperations.DoOperation(req.FromCalculateRequest(), OperationsEnum.Divide));
        }

        [HttpPost("factorial")]
        public IActionResult Factorial([FromBody] CalculateRequest req)
        {
            return this.Json(this.extendedOperations.DoOperation(req.FromCalculateRequest(), OperationsEnum.Factorial));
        }
    }
}
