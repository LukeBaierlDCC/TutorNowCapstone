using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class SubcategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subcategory
        public ActionResult Index()
        {
            return View(db.Subcategory.ToList());
        }

        // GET: Subcategory/Details/5
        public ActionResult SubcategoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory Subcategory = db.Subcategory.Find(id);
            if (Subcategory == null)
            {
                return HttpNotFound();
            }
            return View(Subcategory);
        }

        // GET: Subcategory/Create
        public ActionResult CreateSubcategory()
        {
            Subcategory subcategory = new Subcategory();
            return View(subcategory);
        }

        // POST: Subcategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FieldOfStudy,SubcatId,SubjectId,Name")] Subcategory Subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Subcategory.Add(Subcategory);
                //
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Subcategory);
        }

        // GET: Subcategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory Subcategory = db.Subcategory.Find(id);
            if (Subcategory == null)
            {
                return HttpNotFound();
            }
            return View(Subcategory);
        }

        // POST: Subcategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FieldOfStudy,SubcatId,SubjectId,Name")] Subcategory Subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Subcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Subcategory);
        }

        // GET: Subcategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory Subcategory = db.Subcategory.Find(id);
            if (Subcategory == null)
            {
                return HttpNotFound();
            }
            return View(Subcategory);
        }

        // POST: Subcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcategory Subcategory = db.Subcategory.Find(id);
            db.Subcategory.Remove(Subcategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
