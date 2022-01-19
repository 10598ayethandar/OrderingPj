using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Ordering.Models;

namespace Ordering.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string search, int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(m => m.Food_name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}