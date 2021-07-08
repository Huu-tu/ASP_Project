using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserIdentity.Models;

namespace UserIdentity.Controllers
{
    public class TraineeAsignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        [Authorize(Roles = "Staff, Trainee")]
        public ActionResult Index()
        {
            var traineeAsigns = db.TraineeAsigns.Include(t => t.Course).Include(t => t.Trainee);
            return View(traineeAsigns.ToList());
        }

       
        [Authorize(Roles = "Staff, Trainee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeAsign traineeAsign = db.TraineeAsigns.Find(id);
            if (traineeAsign == null)
            {
                return HttpNotFound();
            }
            return View(traineeAsign);
        }

        [Authorize(Roles = "Staff")]
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "Name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraineeAsignID,TraineeID,CourseID")] TraineeAsign traineeAsign)
        {
            if (ModelState.IsValid)
            {
                db.TraineeAsigns.Add(traineeAsign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", traineeAsign.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "Name", traineeAsign.TraineeID);
            return View(traineeAsign);
        }

        [Authorize(Roles = "Staff")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeAsign traineeAsign = db.TraineeAsigns.Find(id);
            if (traineeAsign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", traineeAsign.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "Name", traineeAsign.TraineeID);
            return View(traineeAsign);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeAsignID,TraineeID,CourseID")] TraineeAsign traineeAsign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traineeAsign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", traineeAsign.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "Name", traineeAsign.TraineeID);
            return View(traineeAsign);
        }

        
        [Authorize(Roles = "Staff")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeAsign traineeAsign = db.TraineeAsigns.Find(id);
            if (traineeAsign == null)
            {
                return HttpNotFound();
            }
            return View(traineeAsign);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraineeAsign traineeAsign = db.TraineeAsigns.Find(id);
            db.TraineeAsigns.Remove(traineeAsign);
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
