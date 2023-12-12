using AutoMapper;
using LibraryManager.Dtos;
using LibraryManager.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    }
}
