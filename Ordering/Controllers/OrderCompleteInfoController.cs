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
    public class OrderCompleteInfoController : Controller
    {
        // GET: OrderCompleteInfo
        public ActionResult Index(string search, int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.OrderCompleteInfoes.Where(m => m.Food_name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }
    }
}