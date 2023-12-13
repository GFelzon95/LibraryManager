using LibraryManager.Models;
using LibraryManager.ViewModels;
using System.Data.Entity;
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
                DocumentTypes = _context.DocumentTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers
                .Include(c => c.DocumentType)
                .SingleOrDefault(c => c.Id == id);

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                DocumentTypes = _context.DocumentTypes.ToList()
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
                    DocumentTypes = _context.DocumentTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }

            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.DocumentTypeId = customer.DocumentTypeId;
                customerInDb.DocumentNumber = customer.DocumentNumber;
                customerInDb.HasABadRecord = customer.HasABadRecord;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}