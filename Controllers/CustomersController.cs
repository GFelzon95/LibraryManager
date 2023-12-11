using LibraryManager.Models;
using LibraryManager.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManager.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer { Id = 0 },
                DocumentTypes = _context.DocumentType.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    DocumentTypes = _context.DocumentType.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}