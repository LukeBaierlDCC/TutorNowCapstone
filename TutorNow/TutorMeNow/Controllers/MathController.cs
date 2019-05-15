using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class MathController : Controller
    {
        ApplicationDbContext db;
        public MathController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Math
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Models.Math> ListOfMath = db.Maths.ToList();
            return View(ListOfMath);
        }

        // GET: Math/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Math math = db.Maths.Find(id);
            if (math == null)
            {
                return HttpNotFound();
            }
            return View(math);
        }

        // GET: Math/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Math/Create
        [HttpPost]
        public ActionResult Create(Models.Math math)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationDbContext db = new ApplicationDbContext();
                db.Maths.Add(math);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Math/Edit/5
        public ActionResult Edit(int id)
        {
            var maths = db.Maths.SingleOrDefault(s => s.MathId == id);
            if (maths == null)
            {
                return HttpNotFound();
            }
            return View(maths);
        }

        // POST: Math/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.Math math)
        {
            try
            {
                // TODO: Add update logic here
                Models.Math thisMath = db.Maths.Find(id);

                thisMath.MathSubcategory = math.MathSubcategory;
                thisMath.MathTutor = math.MathTutor;
                thisMath.MathStudent = math.MathStudent;

                db.SaveChanges();

                return RedirectToAction("Index", "Maths");
            }
            catch
            {
                return View(math);
            }
        }

        // GET: Math/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Maths.Find(id));
        }

        // POST: Math/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var maths = db.Maths.SingleOrDefault(s => s.MathId == id);
            db.Maths.Remove(db.Maths.Find(id));
            db.SaveChanges();

            return View("Index", maths);
        }
    }
}
