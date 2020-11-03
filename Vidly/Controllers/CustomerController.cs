using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private EntContext _context;
        //Dictionary<int, Customer> customers = new Dictionary<int, Customer>
        //{
        //    {1, new Customer{ name = "John Smith" , id = 1}},
        //    {2, new Customer{ name = "Peter Maged" , id = 2}},
        //    {3, new Customer{ name = "Philip Fry" , id = 3}}
        //};

        public CustomerController()
        {
            _context = new EntContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customer
        public ActionResult Index()
        {            
            return View();
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                id = 1;
            
            Customer c = _context.Customers.Include(cu => cu.MembershipType).SingleOrDefault(cu => cu.id == id);
            if(c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        public ActionResult Edit(int id)
        {
            var mt = _context.MembershipType.ToList();
            var c = _context.Customers.SingleOrDefault(cs => cs.id == id);
            var vm = new ManageCustomerViewModel
            {
                MembershipTypes = mt,
                Customer = c            
            };

            return View(vm);

        }

        public ActionResult Add()
        {
            var mt = _context.MembershipType.ToList();
            var vm = new ManageCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = mt,
                
            };

            return View(vm);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ManageCustomerViewModel cust)
        {

            var customer = cust.Customer;
            var mem = _context.MembershipType.ToList();
            var vm = new ManageCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = mem
            };


            if (!ModelState.IsValid)
            {
                if(cust.Customer.id == 0)
                {
                    return View("Add", vm);
                }
                else
                {
                    return View("Edit", vm);
                }
                
            }

            if (cust.Customer.id == 0)
            {
                _context.Customers.Add(cust.Customer);
            }
            else
            {
                var oldCust = _context.Customers.Single(c => c.id == cust.Customer.id);
                //oldCust.name = cust.Customer.name;
                //oldCust.isSubscribed = cust.Customer.isSubscribed;
                //oldCust.birthdate = cust.Customer.birthdate;
                //oldCust.MembershipType = cust.Customer.MembershipType;
                oldCust = cust.Customer;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");

        }

    }
}