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
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.DocumentType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        [HttpDelete]
        public void DeleteCustomers(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
