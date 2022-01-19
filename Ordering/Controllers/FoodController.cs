using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Ordering.Models;
using PagedList;
using PagedList.Mvc;

namespace Ordering.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index(string search, int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(m => m.Food_name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }

        // GET: Food/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(x => x.Food_id == id).FirstOrDefault());
            }
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult Create(Food food)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(food.ImageFile.FileName);
                string extension = Path.GetExtension(food.ImageFile.FileName);
                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                filename = filename + randomNumber.ToString() + extension;
                food.Food_ImagePath = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                food.ImageFile.SaveAs(filename);


                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Foods.Add(food);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(x => x.Food_id == id).FirstOrDefault());
            }
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Food food)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Entry(food).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(x => x.Food_id == id).FirstOrDefault());
            }
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Food food)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    food = dbmodel.Foods.Where(x => x.Food_id == id).FirstOrDefault();
                    dbmodel.Foods.Remove(food);
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

