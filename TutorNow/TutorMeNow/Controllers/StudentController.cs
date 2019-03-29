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

namespace TutorMeNow.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext db;
        // GET: Student

        public StudentController()
        {
            db = new ApplicationDbContext();
        }

        //public ActionResult StudentHome()
        //{
        //    var userLoggedIn = User.Identity.GetUserId();
        //    var currentStudent = db.Students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
        //    var currentZip = db.Students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
        //    var currentSubject = db.Students.Where(s => s.ApplicationUserId == userLoggedIn).Single();
        //    var tutorsInZip = db.Tutors.Where(t => t.Zip == currentStudent.Zip).ToList();

        //    List<Tutor> tutors = new List<Tutor> { };

        //    foreach (var foundTutor in tutorsInZip)
        //    {

        //        if (tutorsInZip == currentZip)
        //        {
        //            tutorsInZip.Add(foundTutor);
        //        }
        //    }
        //    var typeList = Enum.GetNames(typeof(Subjects))
        //    .Cast<>(Subjects)
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

        // GET: Student/Details/5
        //public ActionResult Details(int? id)
        //{
            //if(id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Student student = db.Students.Find(id);
            //if (student == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(student);
        //}

        // GET: Student/Create
        public ActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,Zip")]Student student)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //db.Students.Add(student);
                    //student.ApplicationUserId = User.Identity.GetUserId();
                    //db.SaveChanges();
                    return RedirectToAction("StudentHome");
                }

            }
            catch
            {
                
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        //public ActionResult Edit(int id/*, FormCollection collection*/)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        var editedStudent = db.Students.Where(s => s.StudentId == id).SingleOrDefault();

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
        //        Student thisStudent = db.Students.Find(id);

        //        thisStudent.FirstName = student.FirstName;
        //        thisStudent.LastName = student.LastName;
        //        thisStudent.Zip = student.Zip;

        //        db.SaveChanges();

        //        return RedirectToAction("StudentHome")
        //    }
        //    catch
        //    {
        //        return View(student);
        //    }
        //}
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("StudentHome");
            }
            catch
            {
                return View();
            }
        }
    }
}
