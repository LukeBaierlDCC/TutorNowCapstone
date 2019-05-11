using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TutorMeNow.Models;

namespace TutorMeNow.Controllers
{
    public class TutorController : Controller
    {
        //ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext db;
        public TutorController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Tutor> ListOfTutors = db.tutors.ToList();
            return View(ListOfTutors);
        }

        // GET: Tutor/Details/5
        public ActionResult Details(int id)
        {
            RatingView RatingView = new RatingView();

            RatingView.Tutor = db.tutors.Find(id);
            RatingView.Ratings = new List<Rating>();
            RatingView.Ratings = db.ratings.Where(r => r.TutorId == id).ToList();
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                var states = Extensions.GetDescription(RatingView.Tutor.State);
                client.BaseAddress = new Uri("Https://maps.googleapis.com/maps/api/geocode/");
                HttpResponseMessage response = client.GetAsync($"json?address={RatingView.Tutor.Street}+{RatingView.Tutor.ZipCode},+{RatingView.Tutor.City},+{states}&key=AIzaSyBBA-VL6jTbTGJNW77AsuCuLRVwXB2wKGo").Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result;
                RootObject root = JsonConvert.DeserializeObject<RootObject>(result);

                double Latitude = 0.0;
                double Longitude = 0.0;
                foreach (var item in root.results)
                {
                    Latitude = item.geometry.location.lat;
                    Longitude = item.geometry.location.lng;
                    ViewBag.Lat = Latitude.ToString();
                    ViewBag.Long = Longitude.ToString();
                }
            }
            return View(RatingView);
        }

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

        public ActionResult CreateSubcategory(/*string id*/)
        {
            Subcategory newSubcategory = new Subcategory();
            return View(newSubcategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubcategory([Bind(Include = "FieldOfStudy,SubcatId,SubjectId,Name")] Subcategory Subcategory)
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

                       
        //public ActionResult EditTutor(int id)
        //{
        //    var editedTutor = db.tutors.Where(t => t.TutorId == id).SingleOrDefault();
        //    return View(editedTutor);
        //}

        //[HttpPost]
        //public ActionResult EditTutor(int id, Tutor tutor)
        //{
        //    try
        //    {
        //        var editedTutor = db.tutors.Where(t => t.TutorId == id).SingleOrDefault();
        //        editedTutor.FirstName = tutor.FirstName;
        //        editedTutor.LastName = tutor.LastName;
        //        editedTutor.City = tutor.City;
        //        editedTutor.ZipCode = tutor.ZipCode;
        //        db.SaveChanges();

        //        return RedirectToAction("Tutors");
        //    }
        //    catch
        //    {
        //        return View("Tutors");
        //    }
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tutor = db.tutors.SingleOrDefault(s => s.TutorId == id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Edit(int id, Tutor tutor)
        {
            try
            {
                // TODO: Add update logic here
                Tutor thisTutor = db.tutors.Find(id);

                thisTutor.FirstName = tutor.FirstName;
                thisTutor.LastName = tutor.LastName;
                thisTutor.SubjectName = tutor.SubjectName;
                thisTutor.Subcategory = tutor.Subcategory;
                thisTutor.Gender = tutor.Gender;
                thisTutor.ZipCode = tutor.ZipCode;

                db.SaveChanges();

                return RedirectToAction("Index", "Tutors");
            }
            catch
            {
                return View(tutor);
            }
        }

        // GET: Tutor/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.tutors.Find(id));
        }

        // POST: Tutor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Tutor tutor)
        {
            var tutors = db.tutors.SingleOrDefault(s => s.TutorId == id);
            db.tutors.Remove(db.tutors.Find(id));
            db.SaveChanges();

            return View("Index", tutors);
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

        public ActionResult EditSubcategory(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubcategory([Bind(Include = "FieldOfStudy,SubcatId,SubjectId,Name")] Subcategory Subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Subcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Subcategory);
        }

        public ActionResult DeleteSubcategory(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubcategoryConfirmed(int id)
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
