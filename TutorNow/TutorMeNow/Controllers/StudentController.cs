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
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace TutorMeNow.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        ApplicationDbContext context;
        public StudentController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult StudentHome()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var currentStudent = context.students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
            var currentDate = DateTime.Now;
            int tutorAvailability = GetWeekNumber(currentDate);
            //var currentZip = context.students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
            var currentSubject = context.students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
            var tutorsInZip = context.tutors.Where(t => t.Zip == currentStudent.Zip).ToList();

            List<Models.Tutor> tutors = new List<Models.Tutor> { };

            foreach (var foundTutor in tutorsInZip)
            {
                int tutorHoot = GetWeekNumber(foundTutor.TutorAvailability);
                if (tutorHoot == tutorAvailability)
                //{
                //    tutorsInZip.Add(foundTutor);
                //}
                {
                    tutors.Add(foundTutor);
                }
            }
            var typeList = Enum.GetValues(typeof(Subject))
            .Cast<Subject>()
            .Select(t => new AccessClass
            {
                Subject = ((Subject)t),
            });

            ViewBag.ListData = typeList;

            return View(tutorsInZip);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filter(string id)
        {

            var CurrentUser = User.Identity.GetUserId();
            var studentFound = context.students.Where(g => g.ApplicationUserId == CurrentUser).SingleOrDefault();

            var filteredTutors = context.tutors.Where(t => t.SubjectName.ToString() == id && t.Zip == studentFound.Zip).ToList();
            return View(filteredTutors);
        }

        public ActionResult FilterHighRating()
        {
            var allTutors = context.tutors.ToList();
            var newList = allTutors.OrderByDescending(t => t.AvgRating).ToList();
            return View(newList);
        }

        public int GetWeekNumber(DateTime date)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            int weekNumber = currentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            return weekNumber;
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = context.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult TutorDetails(int? id)
        {
            return View();
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
                    context.students.Add(student);
                    student.ApplicationUserId = User.Identity.GetUserId();
                    context.SaveChanges();
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
                var ratedTutor = context.tutors.Where(t => t.TutorId == id).SingleOrDefault();
                return View(ratedTutor);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Details(int id, Tutor ratedTutor)
        {

            var thisTutor = context.tutors.Where(e => e.TutorId == id).SingleOrDefault();
            if (DateTime.Now > thisTutor.PastSession)
            {
                Rating rating = new Rating();
                rating.AvgRating = ratedTutor.AvgRating;
                rating.TutorId = thisTutor.TutorId;
                context.ratings.Add(rating);
                context.SaveChanges();
                var tutorsRatings = context.ratings.Where(r => r.TutorId == id).ToList();
                List<int> selectedRatings = new List<int>();
                foreach (var filteredRating in tutorsRatings)
                {
                    selectedRatings.Add(filteredRating.AvgRating);
                }
                int sum = selectedRatings.Sum();
                int avgRating = sum / selectedRatings.Count;
                thisTutor.AvgRating = avgRating;
                

                ratedTutor.AvgRating = thisTutor.AvgRating;

                context.SaveChanges();

            }
            return RedirectToAction("StudentHome");
        }

        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        public ActionResult Edit(int id/*, Student student*/)
        {
            try
            {
                var editedStudent = context.students.Where(s => s.StudentId == id).SingleOrDefault();

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
        //        Student thisStudent = context.students.Find.Id;

        //        thisStudent.FirstName = student.FirstName;
        //        thisStudent.LastName = student.LastName;
        //        thisStudent.Zip = student.Zip;

        //        context.SaveChanges();

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
