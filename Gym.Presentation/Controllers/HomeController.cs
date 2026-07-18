using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gym.Presentation.Models;

namespace Gym.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // Home page action method => return home page view
        {
            // 1-  view / Home / Controller Name : HomeController / Action Method : Index.cshtml
            // 2- view / Shared / Controller Name : HomeController / Action Method : Index.cshtml
            return View(); // return home page view
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
