using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Videostore.Models;
using Videostore.ViewModels;

namespace Videostore.Controllers
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

        //Get for New
        public ActionResult New()
        {
            List<MembershipType> membershipTypes = _context.MembershipTypes.ToList();

            CustomerFormViewModel viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer() 

            };

            return View("CustomerForm", viewModel);
        }

        //CREATE Post for New          
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) 
        {
            if (!ModelState.IsValid)
            {
                CustomerFormViewModel viewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    Customer = customer
                };
                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                Customer customerInDb = _context.Customers.Single(c => c.Id == customer.Id); 

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

           
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        //GET
        public ViewResult Index()
        {
            

            return View();
        }

        //GET one
        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        //GET - 
        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id); 

            if(customer == null)
            {
                return HttpNotFound();
            }

            CustomerFormViewModel viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }


      
    }
}