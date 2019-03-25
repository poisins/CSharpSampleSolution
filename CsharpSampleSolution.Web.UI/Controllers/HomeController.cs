namespace CsharpSampleSolution.Web.UI.Controllers
{
    using System.Diagnostics;
    using System.Globalization;
    using CsharpSampleSolution.Common.Requests;
    using CsharpSampleSolution.Web.UI.Configuration;
    using CsharpSampleSolution.Web.UI.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using RestSharp;

    public class HomeController : Controller
    {
        private readonly ApiSettings apiSettings;

        // Get our custom AppSettings
        public HomeController(IOptions<ApiSettings> apiSettings)
        {
            this.apiSettings = apiSettings.Value;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(FormModel model)
        {
            if (this.apiSettings == null)
            {
                return this.BadRequest("API Settings not available");
            }

            if (!this.apiSettings.Endpoints.ContainsKey(model.OperationType))
            {
                return this.BadRequest($"API Endpoint not set for '{model.OperationType}' operation");
            }

            return this.Content(this.PostRequest(
                this.apiSettings.Endpoints[model.OperationType],
                new CalculateRequest { A = model.Input.A, B = model.Input.B }).ToString(CultureInfo.CurrentCulture));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        private decimal PostRequest<T>(string relativeEndpoint, T reqBody)
        {
            // create new request to our WebAPI
            var client = new RestClient(this.apiSettings.BaseUrl);
            var request = new RestRequest(relativeEndpoint, Method.POST);
            request.AddJsonBody(reqBody);

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            var response = client.Execute<decimal>(request);

            if (response.IsSuccessful)
            {
                // and return response from server
                return response.Data;
            }
            else
            {
                // if error, return this for now
                return decimal.MinValue;
            }
        }
    }
}
