using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorMeNow.Controllers
{
    public class GrammarQuizController : Controller
    {
        // GET: GrammarQuiz
        public ActionResult Index()
        {
            return View();
        }

        // GET: GrammarQuiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GrammarQuiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrammarQuiz/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GrammarQuiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GrammarQuiz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GrammarQuiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GrammarQuiz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
