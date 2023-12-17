using LibraryManager.Models;
using LibraryManager.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManager.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        public UsersController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Edit(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            var viewModel = new UserEditViewModel
            {
                Id = id,
                Email = user.Email,
                Roles = _context.Roles.ToList(),
                UserRole = ""
            };

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Save(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UserEditViewModel
                {
                    Id = model.Id,
                    Email = model.Email,
                    Roles = _context.Roles.ToList(),
                    UserRole = ""
                };

                return View("Edit", viewModel);
            }

            var userInDb = _context.Users.SingleOrDefault(u => u.Id == model.Id);

            var roles = this.UserManager.GetRoles(userInDb.Id);
            this.UserManager.RemoveFromRoles(userInDb.Id, roles.ToArray());
            this.UserManager.AddToRole(userInDb.Id, model.UserRole);

            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
    }
}