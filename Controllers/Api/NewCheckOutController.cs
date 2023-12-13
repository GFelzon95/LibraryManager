using LibraryManager.Dtos;
using LibraryManager.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace LibraryManager.Controllers.Api
{
    public class NewCheckOutController : ApiController
    {
        ApplicationDbContext _context;
        public NewCheckOutController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult NewCheckOut(NewCheckOutDto newCheckOut)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newCheckOut.CustomerId);

            var books = _context.Books.Where(m => newCheckOut.BookIds.Contains(m.Id)).ToList();

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available.");
                }

                book.NumberAvailable--;

                var checkOut = new CheckOut
                {
                    Customer = customer,
                    Book = book,
                    DateCheckedOut = DateTime.Now,
                };

                _context.CheckOuts.Add(checkOut);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
