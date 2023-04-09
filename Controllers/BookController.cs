using BookApplication2.Data;
using BookApplication2.Models;
using BookApplication2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;



namespace BookApplication2.Controllers
{
   

    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Buy(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            ViewData["BookTitle"] = book.Name;
            ViewData["BookPrice"] = book.Price;

            return View();
        }

        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Category).Include(b => b.Publisher).ToList();
            return View(books);
        }

        public class ApplicationDbController : Controller
        {
            private readonly ApplicationDbContext _context;

            public ApplicationDbController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: /Book/
            public async Task<IActionResult> Index()
            {
                var books = await _context.Books.Include(b => b.Category).Include(b => b.Publisher).ToListAsync();
                return View(books);
            }

            // GET: /Book/Details
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var book = await _context.Books.Include(b => b.Category).Include(b => b.Publisher).FirstOrDefaultAsync(m => m.Id == id);

                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            }

            // GET: /Book/Create
            public IActionResult Create()
            {
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
                ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
                return View();
            }

            // POST: /Book/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Title,Author,Price,CategoryId,PublisherId")] Book book)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
                ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
                return View(book);
            }

            // GET: /Book/Edit/
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
                ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
                return View(book);
            }

            // POST: /Book/Edit/
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Price,CategoryId,PublisherId")] Book book)
            {
                if (id != book.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(book);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BookExists(book.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
                ViewBag.PublisherId = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
                return View(book);

            }
            private bool BookExists(int id)
            {
                return _context.Books.Any(e => e.Id == id);
            }

        }
        

        [HttpPost]
        public IActionResult Buy2(BuyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Save the user's purchase data to the database
            // ...
            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Buy2(int id)
        //{
        //    var book = _dbContext.Books.Find(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    var viewModel = new BuyViewModel
        //    {
        //        BookName = book.Name,
        //        Price = book.Price
        //    };

        //    return View(viewModel);
        //}
        


    }
}