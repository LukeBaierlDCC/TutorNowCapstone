using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TutorMeNow.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TutorMeNow.Controllers
{
    public class StudentController : Controller
    {
        //ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext db;
        public StudentController()
        {
            db = new ApplicationDbContext();
        }

        //public ActionResult StudentHome()
        //{
        //    var userLoggedIn = User.Identity.GetUserId();
        //    var currentStudent = db.students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
        //    var currentZip = db.students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
        //    var currentSubject = db.students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
        //    var tutorsInZip = db.tutors.Where(t => t.Zip == currentStudent.Zip).ToList();

        //    List<Models.Tutor> tutors = new List<Models.Tutor> { };

        //    foreach (var foundTutor in tutorsInZip)
        //    {
        //        //int currentZip = foundTutor.Zip;
        //        if (tutorsInZip == currentZip)
        //        {
        //            tutorsInZip.Add(foundTutor);
        //        }
        //        {
        //            tutors.Add(foundTutor);
        //        }
        //    }
        //    var typeList = Enum.GetValues(typeof(Subjects))
        //    .Cast<Subjects>()
        //    .Select(t => new AccessClass
        //    {
        //        Subject = ((Subjects)t),
        //    });

        //    ViewBag.ListData = typeList;

        //    return View(tutorsInZip);
        //}
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filter(string id)
        {

            var CurrentUser = User.Identity.GetUserId();
            var studentFound = db.students.Where(g => g.ApplicationUserId == CurrentUser).SingleOrDefault();

            var filteredTutors = db.tutors.Where(t => t.SubjectName.ToString() == id && t.Zip == studentFound.Zip).ToList();
            return View(filteredTutors);
        }

        public ActionResult FilterHighRating()
        {
            var allTutors = db.tutors.ToList();
            var newList = allTutors.OrderByDescending(t => t.AvgRating).ToList();
            return View(newList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult CreateStudent()
        {
            Student student = new Student();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,City,State,Zip,Subject,Subcategory")]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.students.Add(student);
                    student.ApplicationUserId = User.Identity.GetUserId();
                    db.SaveChanges();
                    return RedirectToAction("StudentHome");
                }

            }
            catch
            {
                
            }
            return View(student);
        }

        public ActionResult GiveRating(int id)
        {
            try
            {
                var ratedTutor = db.tutors.Where(t => t.TutorId == id).SingleOrDefault();
                return View(ratedTutor);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult GiveRating(int id, Tutor ratedTutor)
        {
            var thisTutor = db.tutors.Where(e => e.TutorId == id).SingleOrDefault();
            if (DateTime.Now > thisTutor.PastSession)
            {
                Rating rating = new Rating();
                rating.AvgRating = ratedTutor.AvgRating;
                rating.TutorId = thisTutor.TutorId;
                db.ratings.Add(rating);
                db.SaveChanges();
                var tutorsRatings = db.ratings.Where(r => r.TutorId == id).ToList();
                List<int> selectedRatings = new List<int>();
                foreach (var filteredRating in tutorsRatings)
                {
                    selectedRatings.Add(filteredRating.AvgRating);
                }
                int sum = selectedRatings.Sum();
                int avgRating = sum / selectedRatings.Count;
                thisTutor.AvgRating = avgRating;
                

                ratedTutor.AvgRating = thisTutor.AvgRating;

                db.SaveChanges();

            }
            return RedirectToAction("StudentHome");
        }

        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        public ActionResult Edit(int id/*, FormCollection collection*/)
        {
            try
            {
                var editedStudent = db.students.Where(s => s.StudentId == id).SingleOrDefault();

                return View(editedStudent);
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult Edit(Student student)
        //{
        //    try
        //    {
        //        Student thisStudent = db.students.Find.Id;

        //        thisStudent.FirstName = student.FirstName;
        //        thisStudent.LastName = student.LastName;
        //        thisStudent.Zip = student.Zip;

        //        db.SaveChanges();

        //        return RedirectToAction("StudentHome");
        //    }
        //    catch
        //    {
        //        return View(student);
        //    }
        //}

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("StudentHome");
            }
            catch
            {
                return View();
            }
        }
    }
}
