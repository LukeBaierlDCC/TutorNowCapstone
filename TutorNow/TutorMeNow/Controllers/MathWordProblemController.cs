using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class MathWordProblemController : Controller
    {
        ApplicationDbContext db;
        public MathWordProblemController()
        {
            db = new ApplicationDbContext();
        }
        // GET: MathWordQuiz
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<MathWordProblem> ListOfMathWorldProblem = db.MathWordProblems.ToList();
            return View(ListOfMathWorldProblem);
        }

        // GET: MathWordQuiz/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MathWordProblem mathWordProblem = db.MathWordProblems.Find(id);
            if (mathWordProblem == null)
            {
                return HttpNotFound();
            }
            return View(mathWordProblem);
        }

        // GET: MathWordQuiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MathWordQuiz/Create
        [HttpPost]
        public ActionResult Create(MathWordProblem mathWordProblem)
        {
            try
            {
                // TODO: Add insert logic here
                Models.ApplicationDbContext db = new Models.ApplicationDbContext();
                db.MathWordProblems.Add(mathWordProblem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MathWordQuiz/Edit/5
        public ActionResult Edit(int id)
        {
            var mathWordProblems = db.MathWordProblems.SingleOrDefault(s => s.MathId == id);
            if (mathWordProblems == null)
            {
                return HttpNotFound();
            }
            return View(mathWordProblems);
        }

        // POST: MathWordQuiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MathWordProblem mathWordProblem)
        {
            try
            {
                // TODO: Add update logic here
                MathWordProblem thisMathWordProblem = db.MathWordProblems.Find(id);

                thisMathWordProblem.MathQuestion = mathWordProblem.MathQuestion;
                thisMathWordProblem.MathAnswer = mathWordProblem.MathAnswer;

                db.SaveChanges();

                return RedirectToAction("Index", "MathWordProblems");
            }
            catch
            {
                return View(mathWordProblem);
            }
        }

        // GET: MathWordQuiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.MathWordProblems.Find(id));
        }

        // POST: MathWordQuiz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MathWordProblem mathWordProblem)
        {
            var mathWordProblems = db.MathWordProblems.SingleOrDefault(s => s.MathId == id);
            db.MathWordProblems.Remove(db.MathWordProblems.Find(id));
            db.SaveChanges();

            return View("Index", mathWordProblems);
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
