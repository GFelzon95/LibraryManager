using LibraryManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LibraryManager.Controllers.Api
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpGet]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
