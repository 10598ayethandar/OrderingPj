using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ordering.Models;
using PagedList;
using PagedList.Mvc;

namespace Ordering.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(string search, int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Customers.Where(m => m.C_Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            using (DBModel dbmodel = new DBModel())
            {
                 if( customer.C_Name == "Admin" && customer.Password == "aye10598")
                {
                    return RedirectToAction("Index", "OrderCompleteInfo"); 
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is woring......");
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Customers.Add(customer);
                    dbmodel.SaveChanges();

                }
                ModelState.Clear();

                ViewBag.Message = customer.C_Name + " " + "successfully registered";

            }
            return RedirectToAction("Index","Home");
        }
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Customers.Where(x => x.C_Id == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    Customer customer = dbmodel.Customers.Where(x => x.C_Id == id).FirstOrDefault();
                    dbmodel.Customers.Remove(customer);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}