using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BreatheEasyApp.HelperClasses;
using BreatheEasyApp.Models;
using BreatheEasyApp.Models.ViewModels;
using RestSharp;

namespace BreatheEasyApp.Controllers
{
    public class BadgeMilestonesController : Controller
    {
        private BreatheEasyEntities db = new BreatheEasyEntities();

    

        // GET: BadgeMilestones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BadgeMilestone badgeMilestone = db.BadgeMilestones.Find(id);
            if (badgeMilestone == null)
            {
                return HttpNotFound();
            }
            return View(badgeMilestone);
        }

        // GET: BadgeMilestones/Create
        public ActionResult Create()
        {
            ViewBag.ImageActiveID = new SelectList(db.Images, "ImageID", "ContentType");
            ViewBag.ImageInactiveID = new SelectList(db.Images, "ImageID", "ContentType");
            return View();
        }

        // POST: BadgeMilestones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BadgeID,DaysIn,BadgeIcon,ImageActiveID,ImageInactiveID")] BadgeMilestone badgeMilestone)
        {
            if (ModelState.IsValid)
            {
                db.BadgeMilestones.Add(badgeMilestone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageActiveID = new SelectList(db.Images, "ImageID", "ContentType", badgeMilestone.ImageActiveID);
            ViewBag.ImageInactiveID = new SelectList(db.Images, "ImageID", "ContentType", badgeMilestone.ImageInactiveID);
            return View(badgeMilestone);
        }

        // GET: BadgeMilestones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BadgeMilestone badgeMilestone = db.BadgeMilestones.Find(id);
            if (badgeMilestone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageActiveID = new SelectList(db.Images, "ImageID", "ContentType", badgeMilestone.ImageActiveID);
            ViewBag.ImageInactiveID = new SelectList(db.Images, "ImageID", "ContentType", badgeMilestone.ImageInactiveID);
            return View(badgeMilestone);
        }

        // POST: BadgeMilestones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BadgeID,DaysIn,BadgeIcon,ImageActiveID,ImageInactiveID")] BadgeMilestone badgeMilestone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(badgeMilestone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImageActiveID = new SelectList(db.Images, "ImageID", "ContentType", badgeMilestone.ImageActiveID);
            ViewBag.ImageInactiveID = new SelectList(db.Images, "ImageID", "ContentType", badgeMilestone.ImageInactiveID);
            return View(badgeMilestone);
        }

        // GET: BadgeMilestones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BadgeMilestone badgeMilestone = db.BadgeMilestones.Find(id);
            if (badgeMilestone == null)
            {
                return HttpNotFound();
            }
            return View(badgeMilestone);
        }

        // POST: BadgeMilestones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BadgeMilestone badgeMilestone = db.BadgeMilestones.Find(id);
            db.BadgeMilestones.Remove(badgeMilestone);
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
