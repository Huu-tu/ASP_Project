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
    public class TrainerAsignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

      
        [Authorize(Roles = "Staff, Trainer")]
        public ActionResult Index()
        {
            return View(db.TrainerAsigns.ToList());
        }


        [Authorize(Roles = "Staff, Trainer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerAsign trainerAsign = db.TrainerAsigns.Find(id);
            if (trainerAsign == null)
            {
                return HttpNotFound();
            }
            return View(trainerAsign);
        }

        
        [Authorize(Roles = "Staff")]
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerAsignID,Name,TopicID,TrainerID")] TrainerAsign trainerAsign)
        {
            if (ModelState.IsValid)
            {
                db.TrainerAsigns.Add(trainerAsign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainerAsign);
        }

      
        [Authorize(Roles = "Staff")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerAsign trainerAsign = db.TrainerAsigns.Find(id);
            if (trainerAsign == null)
            {
                return HttpNotFound();
            }
            return View(trainerAsign);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerAsignID,Name,TopicID,TrainerID")] TrainerAsign trainerAsign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerAsign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainerAsign);
        }

        
        [Authorize(Roles = "Staff")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerAsign trainerAsign = db.TrainerAsigns.Find(id);
            if (trainerAsign == null)
            {
                return HttpNotFound();
            }
            return View(trainerAsign);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerAsign trainerAsign = db.TrainerAsigns.Find(id);
            db.TrainerAsigns.Remove(trainerAsign);
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
