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
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

      
        [Authorize]
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Term).Include(c => c.Topic).Include(c => c.Trainer);
            return View(courses.ToList());
        }

        
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

       
        [Authorize(Roles = "Staff")]
        public ActionResult Create()
        {
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "TermName");
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName");
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,CourseName,CourseDescription,TrainerID,TopicID,TermID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TermID = new SelectList(db.Terms, "TermID", "TermName", course.TermID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", course.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "Name", course.TrainerID);
            return View(course);
        }

        
        [Authorize(Roles = "Staff")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "TermName", course.TermID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", course.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "Name", course.TrainerID);
            return View(course);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,CourseDescription,TrainerID,TopicID,TermID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "TermName", course.TermID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", course.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "Name", course.TrainerID);
            return View(course);
        }

        
        [Authorize(Roles = "Staff")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
