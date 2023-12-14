using AutoMapper;
using LibraryManager.Dtos;
using LibraryManager.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryManager.Controllers.Api
{
    public class BooksController : ApiController
    {
        ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            return _context.Books
                .Include(b => b.Genre)
                .ToList()
                .Select(Mapper.Map<Book, BookDto>);
        }

        [HttpPut]
        public void returnBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            bookInDb.NumberAvailable++;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
        }
    }
}
