namespace CsharpSampleSolution.Tests.Integration
{
    using CsharpSampleSolution.Common;
    using CsharpSampleSolution.Common.Extensions;
    using CsharpSampleSolution.Tests.Data;
    using Microsoft.AspNetCore.Hosting;
    using NUnit.Framework;
    using RestSharp;

    [TestFixture]
    public class SampleTests
    {
        private const string ApiHostUrl = "http://localhost:55102";
        private const string EndpointRoot = "/api/calculate/";

        private IWebHost apiHost;

        [OneTimeSetUp]
        public void Init()
        {
            // Create self-hosted (Kestrel) WebAPI
            // Use the same config from existing WebAPI project, so it will be the same as we would run debug in our IDE
            // Just specify differen base URL for our host
            this.apiHost = new WebHostBuilder()
                .UseKestrel()
                .UseEnvironment("Testing")
                .UseStartup<Web.API.Startup>()
                .UseUrls(ApiHostUrl)
                .Build();

            // Start our WebAPI in background otherwise it will block the thread and tests will be stuck at this line
            this.apiHost.RunAsync();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            // Stop our WebAPI's background task
            this.apiHost.StopAsync();
        }

        // These tests are basically the same as in Unit tests, only a bit modified so they use API calls
        #region Response should match

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Add))]
        public decimal DoOperations_Add_Correct(IOperationObject opObj)
        {
            return this.PostRequest(EndpointRoot + "add", opObj.ToCalculateRequest());
        }

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Subtract))]
        public decimal DoOperations_Subtract_Correct(IOperationObject opObj)
        {
            return this.PostRequest(EndpointRoot + "subtract", opObj.ToCalculateRequest());
        }

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Multiply))]
        public decimal DoOperations_Multiply_Correct(IOperationObject opObj)
        {
            return this.PostRequest(EndpointRoot + "multiply", opObj.ToCalculateRequest());
        }

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Divide))]
        public decimal DoOperations_Divide_Correct(IOperationObject opObj)
        {
            return this.PostRequest(EndpointRoot + "divide", opObj.ToCalculateRequest());
        }

        [TestCaseSource(typeof(OperationsTestData), nameof(OperationsTestData.Factorial))]
        public decimal DoOperations_Factorial_Correct(IOperationObject opObj)
        {
            return this.PostRequest(EndpointRoot + "factorial", opObj.ToCalculateRequest());
        }

        #endregion

        #region Response should not match

        [Test]
        public void Factorial_InCorrect()
        {
            Assert.AreNotEqual(10, this.PostRequest(EndpointRoot + "factorial", new OperationObject<int, double>(5, 0)));
        }

        #endregion

        private decimal PostRequest<T>(string relativeEndpoint, T reqBody)
        {
            // create new request to our WebAPI
            var client = new RestClient(ApiHostUrl);
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