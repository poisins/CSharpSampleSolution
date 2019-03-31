namespace CsharpSampleSolution.Tests.E2E
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class SampleTests
    {
        private const string ApiHostUrl = "http://localhost:55202";
        private const string UiHostUrl = "http://localhost:55201";

        private IWebHost apiHost;
        private IWebHost uiHost;

        private IWebDriver webDriver;
        private DriverService driverService;

        [OneTimeSetUp]
        public void Init()
        {
            this.SetUpHosts();
            this.SetUpWebDriver();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            // Stop our WebAPI and WebUI background tasks
            this.apiHost.StopAsync();
            this.uiHost.StopAsync();

            // Close Selenium WebDriver
            this.webDriver.Quit();
            this.driverService.Dispose();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        private void SetUpHosts()
        {
            // Create self-hosted (Kestrel) WebAPI and WebUI
            // Use the same config from existing WebAPI/WebUI project, so it will be the same as we would run debug in our IDE
            // Just specify differen base URL for our host
            this.apiHost = new WebHostBuilder()
                .UseKestrel()
                .UseEnvironment("Testing")
                .UseStartup<Web.API.Startup>()
                .UseUrls(ApiHostUrl)
                .Build();

            this.uiHost = new WebHostBuilder()
                .UseKestrel()
                .UseEnvironment("Testing")
                .UseStartup<Web.UI.Startup>()
                .UseUrls(UiHostUrl)
                .Build();

            // Start our WebAPI and WebUI in background otherwise it will block the thread and tests will be stuck at this line
            this.apiHost.RunAsync();
            this.uiHost.RunAsync();
        }

        private void SetUpWebDriver()
        {
            // Fix for WebDriver not found issue in .NET Core
            var currentDirectory = Directory.GetCurrentDirectory();
            this.driverService = ChromeDriverService.CreateDefaultService(currentDirectory);
            this.driverService.Start();

            this.webDriver = new ChromeDriver(this.driverService as ChromeDriverService);
            WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(10));
            this.webDriver.Navigate().GoToUrl(new Uri(UiHostUrl));
        }
    }
}