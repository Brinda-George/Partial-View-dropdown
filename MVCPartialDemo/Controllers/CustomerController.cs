using MVCPartialDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPartialDemo.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            DetailsEntities DbContext = new DetailsEntities();
            List<Customer> Customers = DbContext.Customers.OrderBy(c => c.Name).ToList();
            return View(Customers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var age = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Twenty",
                    Value = "20"
                },
                new SelectListItem
                {
                    Text = "Twenty One",
                    Value = "21"
                },
                new SelectListItem
                {
                    Text = "Twenty Two",
                    Value = "22"
                }
            };
            ViewBag.Age = age;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                DetailsEntities DbContext = new DetailsEntities();
                DbContext.Customers.Add(customer);
                DbContext.SaveChanges();
                return Json(new { message = "saved successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(customer);
            }
        }
        public JsonResult IsValidName(string Name)
        {
            DetailsEntities dbContext = new DetailsEntities();
            Customer customer = dbContext.Customers.Where(c => c.Name == Name).FirstOrDefault();
            bool isValid = customer == null ? true : false;

            return Json(isValid, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchCust()
        {
            return View();
        }

        public ActionResult Search(Customer cust)
        {
            DetailsEntities dbContext = new DetailsEntities();
            Customer customer = dbContext.Customers.Where(c => c.Name == cust.Name).FirstOrDefault();
            return PartialView("Search", customer);
        }
    }
}