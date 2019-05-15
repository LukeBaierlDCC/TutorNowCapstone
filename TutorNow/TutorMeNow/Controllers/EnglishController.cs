using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class EnglishController : Controller
    {
        ApplicationDbContext db;
        public EnglishController()
        {
            db = new ApplicationDbContext();
        }
        // GET: English
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<English> ListOfEnglish = db.Englishes.ToList();
            return View(ListOfEnglish);
        }

        // GET: English/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English english = db.Englishes.Find(id);
            if (english == null)
            {
                return HttpNotFound();
            }
            return View(english);
        }

        // GET: English/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: English/Create
        [HttpPost]
        public ActionResult Create(English english)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationDbContext db = new ApplicationDbContext();
                db.Englishes.Add(english);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: English/Edit/5
        public ActionResult Edit(int id)
        {
            var englishes = db.Englishes.SingleOrDefault(s => s.EnglishId == id);
            if (englishes == null)
            {
                return HttpNotFound();
            }
            return View(englishes);
        }

        // POST: English/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, English english)
        {
            try
            {
                // TODO: Add update logic here
                English thisEnglish = db.Englishes.Find(id);

                thisEnglish.EnglishSubcategory = english.EnglishSubcategory;
                thisEnglish.EnglishTutor = english.EnglishTutor;
                thisEnglish.EnglishStudent = english.EnglishStudent;

                db.SaveChanges();

                return RedirectToAction("Index", "Englishes");
            }
            catch
            {
                return View(english);
            }
        }

        // GET: English/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Englishes.Find(id));
        }

        // POST: English/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, English english)
        {
            var englishes = db.Englishes.SingleOrDefault(s => s.EnglishId == id);
            db.Englishes.Remove(db.Englishes.Find(id));
            db.SaveChanges();

            return View("Index", englishes);
        }
    }
}
