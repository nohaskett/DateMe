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
            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

            return View("DatingApplication", new Application());
        }
        [HttpPost]
        public IActionResult DatingApplication(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Applications.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else // Invalid data
            {
                ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

                return View(response);
            }
            
        }

        public IActionResult WaitList()
        {
            // Linq
            var applications = _context.Applications
                .Where(x => x.CreeperStalker == false)
                .OrderBy(x => x.LastName).ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Applications
                .Single(x => x.ApplicationId == id);

            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

            return View("DatingApplication", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("WaitList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Applications
                .Single(x => x.ApplicationId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application application)
        {
            _context.Applications.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("WaitList");
        }
    }
}
