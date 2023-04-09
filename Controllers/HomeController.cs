using BookApplication2.Data;
using BookApplication2.Models;
using BookApplication2.Data;
using BookApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var cheapestBooks = _context.Books.OrderBy(b => b.Price).Take(3).ToList();
            return View(cheapestBooks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Buy(string name, string address, string creditCardNumber, string creditCardExpiry, string creditCardCVV)
        {
            // Save the form data to the database
            // ...

            return RedirectToAction("Index");
        }


    }
}