using AutoMapper;
using LibraryManager.Dtos;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace LibraryManager.Controllers.Api
{
    public class CheckOutsController : ApiController
    {
        ApplicationDbContext _context;

        public CheckOutsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CheckOutDto> GetCheckOuts()
        {
            return _context.CheckOuts
                .Include(c => c.Customer)
                .Include(c => c.Book)
                .ToList()
                .Select(Mapper.Map<CheckOut, CheckOutDto>);
        }

        [HttpPut]
        public void UpdateCheckOut(int id)
        {
            var customerInDb = _context.CheckOuts.SingleOrDefault(c => c.Id == id);

            customerInDb.DateReturned = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
