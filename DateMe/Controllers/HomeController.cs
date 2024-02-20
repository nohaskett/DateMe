using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private DatingApplicationContext _context;
        
        public HomeController(DatingApplicationContext temp) // Constructor, when Home Controller is built, bring na instance of the database
        {
            _context = temp;
        }

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
            _context.Applications.Add(response); // Add record to the database
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult WaitList()
        {
            // Linq
            var applications = _context.Applications
                .Where(x => x.CreeperStalker == false)
                .OrderBy(x => x.LastName).ToList();

            return View(applications);
        }
    }
}
