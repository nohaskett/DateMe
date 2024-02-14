using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DatingApplication() // The action doesn't have to be the same as the view, but it can
        {
            return View("DatingApplication");
        }
        [HttpPost]
        public IActionResult DatingApplication(Application response)
        {
            return View("Confirmation");
        }
    }
}
