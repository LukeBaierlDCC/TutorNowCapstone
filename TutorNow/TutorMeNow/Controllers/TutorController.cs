using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            return View();
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
                HttpResponseMessage response = client.GetAsync($"json?address={RatingView.Tutor.Street}+{RatingView.Tutor.Zip},+{RatingView.Tutor.City},+{states}&key=AIzaSyBBA-VL6jTbTGJNW77AsuCuLRVwXB2wKGo").Result;
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
            Subcategory newSubcategory = new Subcategory();
            return View(newSubcategory);
        }

        //[HttpPost]
        //public ActionResult NewSubcategory(Subcategory Subcategory)
        //{
        //    var CurrentUser = User.Identity.GetUserId();

        //    var tutorFound = db.tutors.Where(t => t.ApplicationUserId == CurrentUser).SingleOrDefault();
        //    try
        //    {
        //        var NewSubcategory = new Subcategory
        //        {

        //            SubjectId = tutorFound.TutorId,
        //            SubcategoryId = tutorFound.TutorId

        //        };

        //        db.tutors.Add(NewSubcategory);
        //        db.SaveChanges();
        //        return View("Subcategory");
        //    }
        //    catch
        //    {
        //        return View("Subcategory");
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
