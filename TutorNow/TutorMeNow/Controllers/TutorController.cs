using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class TutorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Tutor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateTutor()
        {
            Tutor tutor = new Tutor();
            return View("CreateTutor", tutor);
        }

        [HttpPost]
        public ActionResult CreateTutor(Tutor tutor)
        {
            try
            {
                db.tutors.Add(tutor);
                tutor.ApplicationUserId = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("Tutors");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateNewSubcategory(string id)
        {
            Subcategories newSubcategory = new Subcategories();
            return View(newSubcategory);
        }

        //[HttpPost]
        //public ActionResult CreateNewSubcategory(Subcategories subcategories)
        //{
        //    var CurrentUser = User.Identity.GetUserId();

        //    var tutorFound = db.tutors.Where(t => t.ApplicationUserId == CurrentUser).SingleOrDefault();
        //    try
        //    {
        //        var CreateNewSubcategory = new Subcategories
        //        {

        //            SubjectId = tutorFound.TutorId,
        //            SubcatId = tutorFound.TutorId

        //        };

        //        db.tutors.Add(CreateNewSubcategory);
        //        db.SaveChanges();
        //        return View("Subcategories");
        //    }
        //    catch
        //    {
        //        return View("Subcategories");
        //    }
        //}

        public ActionResult EditTutor(int id)
        {
            var editedTutor = db.tutors.Where(t => t.TutorId == id).SingleOrDefault();
            return View(editedTutor);
        }

        [HttpPost]
        public ActionResult EditTutor(int id, Tutor tutor)
        {
            try
            {
                var editedTutor = db.tutors.Where(t => t.TutorId == id).SingleOrDefault();
                editedTutor.FirstName = tutor.FirstName;
                editedTutor.LastName = tutor.LastName;
                editedTutor.City = tutor.City;
                editedTutor.Zip = tutor.Zip;
                db.SaveChanges();

                return RedirectToAction("Tutors");
            }
            catch
            {
                return View("Tutors");
            }
        }

        // GET: Tutor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tutor/Delete/5
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
