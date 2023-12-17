using LibraryManager.Models;
using System.Web.Mvc;

namespace LibraryManager.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View("List");
        }
    }
}