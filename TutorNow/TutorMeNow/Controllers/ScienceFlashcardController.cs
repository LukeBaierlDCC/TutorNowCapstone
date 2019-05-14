using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class ScienceFlashcardController : Controller
    {
        ApplicationDbContext db;
        public ScienceFlashcardController()
        {
            db = new ApplicationDbContext();
        }
        // GET: ScienceWordQuiz
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<ScienceFlashcard> ListOfScienceFlashcard = db.ScienceFlashcards.ToList();
            return View(ListOfScienceFlashcard);
        }

        // GET: ScienceWordQuiz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScienceFlashcard scienceFlashcard = db.ScienceFlashcards.Find(id);
            if (scienceFlashcard == null)
            {
                return HttpNotFound();
            }
            return View(scienceFlashcard);
        }

        // GET: ScienceWordQuiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScienceWordQuiz/Create
        [HttpPost]
        public ActionResult Create(ScienceFlashcard scienceFlashcard)
        {
            try
            {
                // TODO: Add insert logic here
                Models.ApplicationDbContext db = new Models.ApplicationDbContext();
                db.ScienceFlashcards.Add(scienceFlashcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ScienceWordQuiz/Edit/5
        public ActionResult Edit(int id)
        {
            var scienceFlashcards = db.ScienceFlashcards.SingleOrDefault(s => s.ScienceId == id);
            if (scienceFlashcards == null)
            {
                return HttpNotFound();
            }
            return View(scienceFlashcards);
        }

        // POST: ScienceWordQuiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ScienceFlashcard scienceFlashcard)
        {
            try
            {
                // TODO: Add update logic here
                ScienceFlashcard thisScienceFlashcard = db.ScienceFlashcards.Find(id);

                thisScienceFlashcard.ScienceQuestion = scienceFlashcard.ScienceQuestion;
                thisScienceFlashcard.ScienceAnswer = scienceFlashcard.ScienceAnswer;

                db.SaveChanges();

                return RedirectToAction("Index", "ScienceFlashcards");
            }
            catch
            {
                return View(scienceFlashcard);
            }
        }

        // GET: ScienceWordQuiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.ScienceFlashcards.Find(id));
        }

        // POST: ScienceWordQuiz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ScienceFlashcard scienceFlashcard)
        {
            var scienceFlashcards = db.ScienceFlashcards.SingleOrDefault(s => s.ScienceId == id);
            db.ScienceFlashcards.Remove(db.ScienceFlashcards.Find(id));
            db.SaveChanges();

            return View("Index", scienceFlashcard);
            //try
            //{
            //    // TODO: Add delete logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
