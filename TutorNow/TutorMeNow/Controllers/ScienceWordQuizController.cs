using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorMeNow.Controllers
{
    public class ScienceWordQuizController : Controller
    {
        // GET: ScienceWordQuiz
        public ActionResult Index()
        {
            return View();
        }

        // GET: ScienceWordQuiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScienceWordQuiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScienceWordQuiz/Create
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

        // GET: ScienceWordQuiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScienceWordQuiz/Edit/5
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

        // GET: ScienceWordQuiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScienceWordQuiz/Delete/5
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
