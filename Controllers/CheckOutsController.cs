using System.Web.Mvc;

namespace LibraryManager.Controllers
{
    public class CheckOutsController : Controller
    {
        // GET: CheckOuts
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}