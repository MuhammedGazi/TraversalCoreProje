using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index sayfas� �a�r�ld�");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime date =Convert.ToDateTime(DateTime.Now.ToLongDateString());
            _logger.LogInformation(date+" Privacy sayfas� �a�r�ld�");
            return View();
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfas� �a�r�ld�");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
