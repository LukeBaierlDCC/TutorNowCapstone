using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            ApplicationDbContext db = new ApplicationDbContext();
            List<FieldOfStudy> ListOfFieldOfStudies = db.FieldOfStudies.ToList();
            return View(ListOfFieldOfStudies);
        }

        // GET: FieldOfStudy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOfStudy fieldOfStudy = db.FieldOfStudies.Find(id);
            if (fieldOfStudy == null)
            {
                return HttpNotFound();
            }
            return View(fieldOfStudy);
        }

        // GET: FieldOfStudy/Create
        public ActionResult Create()
        {
            FieldOfStudy fieldOfStudy = new FieldOfStudy();
            return View(fieldOfStudy);
        }

        // POST: FieldOfStudy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Math,English,Science")] FieldOfStudy fieldOfStudy)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationDbContext db = new ApplicationDbContext();
                db.FieldOfStudies.Add(fieldOfStudy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(fieldOfStudy);
            }
        }

        // GET: FieldOfStudy/Edit/5
        public ActionResult Edit(int id)
        {
            var fieldOfStudy = db.FieldOfStudies.SingleOrDefault(s => s.SubjectId == id);
            if (fieldOfStudy == null)
            {
                return HttpNotFound();
            }
            return View(fieldOfStudy);
        }

        // POST: FieldOfStudy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FieldOfStudy fieldOfStudy)
        {
            try
            {
                FieldOfStudy thisFieldOfStudy = db.FieldOfStudies.Find(id);

                thisFieldOfStudy.Math = fieldOfStudy.Math;
                thisFieldOfStudy.English = fieldOfStudy.English;
                thisFieldOfStudy.Science = fieldOfStudy.Science;

                return RedirectToAction("Index", "FieldOfStudy");
            }
            catch
            {
                return View(fieldOfStudy);
            }
        }

        // GET: FieldOfStudy/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.FieldOfStudies.Find(id));
        }

        // POST: FieldOfStudy/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FieldOfStudy fieldOfStudy)
        {
            var fieldOfStudies = db.FieldOfStudies.SingleOrDefault(s => s.SubjectId == id);
            db.FieldOfStudies.Remove(db.FieldOfStudies.Find(id));
            db.SaveChanges();

            return View("Index", fieldOfStudy);
        }
    }
}
