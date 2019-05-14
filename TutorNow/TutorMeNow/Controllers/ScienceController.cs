using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class ScienceController : Controller
    {
        ApplicationDbContext db;
        public ScienceController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Science
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Science> ListOfScience = db.Sciences.ToList();
            return View(ListOfScience);
        }

        // GET: Science/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Science science = db.Sciences.Find(id);
            if (science == null)
            {
                return HttpNotFound();
            }
            return View(science);
        }

        // GET: Science/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Science/Create
        [HttpPost]
        public ActionResult Create(Science science)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationDbContext db = new ApplicationDbContext();
                db.Sciences.Add(science);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Science/Edit/5
        public ActionResult Edit(int id)
        {
            var sciences = db.Sciences.SingleOrDefault(s => s.ScienceId == id);
            if (sciences == null)
            {
                return HttpNotFound();
            }
            return View(sciences);
        }

        // POST: Science/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Science science)
        {
            try
            {
                // TODO: Add update logic here
                Science thisScience = db.Sciences.Find(id);

                thisScience.ScienceSubcategory = science.ScienceSubcategory;

                db.SaveChanges();

                return RedirectToAction("Index", "Sciences");
            }
            catch
            {
                return View(science);
            }
        }

        // GET: Science/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Sciences.Find(id));
        }

        // POST: Science/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Science science)
        {
            var sciences = db.Sciences.SingleOrDefault(s => s.ScienceId == id);
            db.Sciences.Remove(db.Sciences.Find(id));
            db.SaveChanges();

            return View("Index", sciences);
        }
    }
}
