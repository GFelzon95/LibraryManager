using LibraryManager.Models;
using LibraryManager.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManager.Controllers
{
    public class BooksController : Controller
    {
        ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new BookFormViewModel
            {
                Book = new Book { Id = 0 },
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", viewModel);
        }

        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel
                {
                    Book = book,
                    Genres = _context.Genres.ToList()
                };

                return View("BookForm", viewModel);
            }

            book.NumberAvailable = book.NumberInStock;
            _context.Books.Add(book);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}