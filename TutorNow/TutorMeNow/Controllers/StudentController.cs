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
        ApplicationDbContext db;
        public StudentController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult StudentHome()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var currentStudent = db.students.Where(s => s.ApplicationUserId == userLoggedIn).SingleOrDefault();
            var currentDate = DateTime.Now;
            int tutorAvailability = GetWeekNumber(currentDate);
            //int currentZip = db.students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
            var currentSubject = db.students.Where(s => s.ApplicationUserId == userLoggedIn).SingleOrDefault();
            var tutorsInZip = db.tutors.Where(t => t.ZipCode == currentStudent.ZipCode).ToList();

            List<Tutor> tutors = new List<Tutor> { };

            foreach (var foundTutor in tutorsInZip)
            {
                int tutorsInZipCode = GetWeekNumber(foundTutor.TutorAvailability);
                if (tutorsInZipCode == tutorAvailability)
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
                Subject = t,
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
            var studentFound = db.students.Where(g => g.ApplicationUserId == CurrentUser).SingleOrDefault();

            var filteredTutors = db.tutors.Where(t => t.SubjectName.ToString() == id && t.ZipCode == studentFound.ZipCode).ToList();
            return View(filteredTutors);
        }

        public ActionResult FilterHighRating()
        {
            var allTutors = db.tutors.ToList();
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
            Student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult TutorDetails(int id)
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
        public ActionResult CreateStudent()
        {
            Student student = new Student();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,City,State,ZipCode,Subject,Subcategory,LearningGoal")]Student student)
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
                return View();
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

        //public ActionResult Edit(int id/*, Student student*/)
        //{
        //    try
        //    {
        //        var editedStudent = db.students.Where(s => s.StudentId == id).SingleOrDefault();

        //        return View(editedStudent);
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, Student student)
        //{
        //    try
        //    {
        //        Student thisStudent = db.students.Find(id);

        //        thisStudent.FirstName = student.FirstName;
        //        thisStudent.LastName = student.LastName;
        //        thisStudent.ZipCode = student.ZipCode;

        //        db.SaveChanges();

        //        return RedirectToAction("StudentHome");
        //    }
        //    catch
        //    {
        //        return View(student);
        //    }
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = db.students.SingleOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Edit(int id, Student student)
        {
            try
            {
                // TODO: Add update logic here
                Student thisStudent = db.students.Find(id);

                thisStudent.FirstName = student.FirstName;
                thisStudent.LastName = student.LastName;
                thisStudent.SubjectName = student.SubjectName;
                //thisStudent.Subcategory = student.Subcategory;
                //thisStudent.FieldOfStudy = student.FieldOfStudy;
                thisStudent.Gender = student.Gender;
                thisStudent.ZipCode = student.ZipCode;
                thisStudent.LearningGoal = student.LearningGoal;

                db.SaveChanges();

                return RedirectToAction("Index", "Students");
            }
            catch
            {
                return View(student);
            }
        }

        //public ViewResult LearningGoal(Student student)
        //{
            
        //}

        public ActionResult Delete(int id)
        {
            return View(db.students.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            var students = db.students.SingleOrDefault(s => s.StudentId == id);
            db.students.Remove(db.students.Find(id));
            db.SaveChanges();

            return View("Index", students);
            //try
            //{

            //    return RedirectToAction("StudentHome");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
