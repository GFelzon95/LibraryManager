using LibraryManager.Models;
using LibraryManager.ViewModels;
using System.Data.Entity;
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

        public ActionResult Edit(int id)
        {
            var book = _context.Books
                .Include(b => b.Genre)
                .SingleOrDefault(b => b.Id == id);

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList()
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            if (book.Id == 0)
            {
                book.NumberAvailable = book.NumberInStock;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.SingleOrDefault(b => b.Id == book.Id);
                var numberInStockDifference = book.NumberInStock - bookInDb.NumberInStock;


                bookInDb.Name = book.Name;
                bookInDb.Author = book.Author;
                bookInDb.Description = book.Description;
                bookInDb.GenreId = book.GenreId;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.NumberAvailable += (byte)numberInStockDifference;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
    }
}