using TutorNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace TutorNow.Controllers
{
    public class StudentController : Controller
    {
        //ApplicationDbContext db;
        // GET: Student
        public StudentController()
        {
            //db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            //var userLoggedin = User.Identity.GetUserId();

            //var students = db.Student.Where(s => s.UserId == userLoggedin).Include;
            return View();
        }

        // GET: Student/Details/5
        //public ActionResult Details(int id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        //[HttpPost]
        //public ActionResult Create([Bind(Include = "FirstName, LastName, City, State, Zip")]Student student)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        if (ModelState.IsValid)
        //        {
        //            /*db.Students.Add(student);
        //            db.SaveChanges();*/
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch /*(Data)*/
        //    {
        //        return View();
        //    }
        //}

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
