namespace CsharpSampleSolution.Web.UI.Controllers
{
    using System.Diagnostics;
    using CsharpSampleSolution.Web.UI.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(FormModel model)
        {
            return this.Content($"Hello {model.Input.A}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
