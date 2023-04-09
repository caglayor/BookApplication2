using BookApplication2.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication2.Controllers
{
   

    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MenuController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();
            return View(categories);
        }
    }

}
