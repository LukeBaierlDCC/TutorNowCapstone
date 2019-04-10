using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class FieldOfStudyController : Controller
    {
        ApplicationDbContext db;
        public FieldOfStudyController()
        {
            db = new ApplicationDbContext();
        }
        // GET: FieldOfStudy
        public ActionResult Index()
        {
            return View();
        }

        // GET: FieldOfStudy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FieldOfStudy/Create
        public ActionResult Create()
        {
            Subcategory subcategory = new Subcategory();
            return View(subcategory);
        }

        // POST: FieldOfStudy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Math,English,Science")] Subcategory subcategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Subcategory.Add(subcategory);
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                
            }
            return View(subcategory);
        }

        // GET: FieldOfStudy/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var editedFieldOfStudy = db.tutors.Where(t => t.TutorId == id).SingleOrDefault();
                return View(editedFieldOfStudy);
            }
            catch
            {
                return View();
            }
        }

        // POST: FieldOfStudy/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FieldOfStudy fieldOfStudy)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FieldOfStudy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FieldOfStudy/Delete/5
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
