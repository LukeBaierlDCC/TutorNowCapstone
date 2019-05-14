using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class GrammarFlashcardController : Controller
    {
        ApplicationDbContext db;
        public GrammarFlashcardController()
        {
            db = new ApplicationDbContext();
        }
        // GET: GrammarFlashcard
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<GrammarFlashcard> ListOfGrammarFlashcard = db.GrammarFlashcards.ToList();
            return View(ListOfGrammarFlashcard);
        }

        // GET: GrammarFlashcard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrammarFlashcard grammarFlashcard = db.GrammarFlashcards.Find(id);
            if (grammarFlashcard == null)
            {
                return HttpNotFound();
            }
            return View(grammarFlashcard);
        }

        // GET: GrammarFlashcard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrammarFlashcard/Create
        [HttpPost]
        public ActionResult Create(GrammarFlashcard grammarFlashcard)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationDbContext db = new ApplicationDbContext();
                db.GrammarFlashcards.Add(grammarFlashcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GrammarFlashcard/Edit/5
        public ActionResult Edit(int id)
        {
            var grammarFlashcards = db.GrammarFlashcards.SingleOrDefault(s => s.GrammarId == id);
            if (grammarFlashcards == null)
            {
                return HttpNotFound();
            }
            return View(grammarFlashcards);
            //return View();
        }

        // POST: GrammarFlashcard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GrammarFlashcard grammarFlashcard)
        {
            try
            {
                // TODO: Add update logic here
                GrammarFlashcard thisGrammarFlashcard = db.GrammarFlashcards.Find(id);

                thisGrammarFlashcard.GrammarQuestion = grammarFlashcard.GrammarQuestion;
                thisGrammarFlashcard.GrammarAnswer = grammarFlashcard.GrammarAnswer;

                db.SaveChanges();

                return RedirectToAction("Index", "GrammarFlashcards");
            }
            catch
            {
                return View(grammarFlashcard);
            }
        }

        // GET: GrammarFlashcard/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.GrammarFlashcards.Find(id));
        }

        // POST: GrammarFlashcard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GrammarFlashcard grammarFlashcard)
        {
            var grammarFlashcards = db.GrammarFlashcards.SingleOrDefault(s => s.GrammarId == id);
            db.GrammarFlashcards.Remove(db.GrammarFlashcards.Find(id));
            db.SaveChanges();

            return View("Index", grammarFlashcards);
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
