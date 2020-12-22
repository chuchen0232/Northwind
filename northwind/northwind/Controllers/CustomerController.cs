using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace northwind.Controllers
{
    public class CustomerController : Controller
    {
        dbNorthwindEntities db = new dbNorthwindEntities();

        // GET: Customer
        public ActionResult List()
        {
            var customers = db.Customers.OrderBy(m => m.CustomerID).ToList();
            return View(customers);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers c)
        {
            if (string.IsNullOrEmpty(c.CustomerID))
                return RedirectToAction("List");
            //
            db.Customers.Add(c);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(string id)
        {
            /*
            var customer = db.Customers.Where(m => m.CustomerID == id).FirstOrDefault();
            db.Customers.Remove(customer);
            db.SaveChanges();
            */
            Customers prod = db.Customers.FirstOrDefault(m => m.CustomerID==id);
            if (prod != null)
            {
                db.Customers.Remove(prod);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public ActionResult Edit(string id)
        {
            var customer = db.Customers.Where(m => m.CustomerID == id).FirstOrDefault();
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customers modify)
        {
            var customer = db.Customers.Where(m => m.CustomerID == modify.CustomerID).FirstOrDefault();
            if (customer != null)
            {
                customer.CompanyName = modify.CompanyName;
                customer.ContactName = modify.ContactName;
                customer.ContactTitle = modify.ContactTitle;
                customer.Address = modify.Address;
                customer.City = modify.City;
                customer.Region = modify.Region;
                customer.PostalCode = modify.PostalCode;
                customer.Country = modify.Country;
                customer.Phone = modify.Phone;
                customer.Fax = modify.Fax;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}