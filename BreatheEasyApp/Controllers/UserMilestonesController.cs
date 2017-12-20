using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BreatheEasyApp.Models;

namespace BreatheEasyApp.Controllers
{
    public class UserMilestonesController : Controller
    {
        private BreatheEasyEntities db = new BreatheEasyEntities();

        // GET: UserMilestones
        public ActionResult Index()
        {
            var userMilestones = db.UserMilestones.Include(u => u.UserInfo);
            return View(userMilestones.ToList());
        }

        // GET: UserMilestones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMilestone userMilestone = db.UserMilestones.Find(id);
            if (userMilestone == null)
            {
                return HttpNotFound();
            }
            return View(userMilestone);
        }

        // GET: UserMilestones/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UserInfoes, "ID", "UserID");
            return View();
        }

        // POST: UserMilestones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Target,Date")] UserMilestone userMilestone)
        {
            if (ModelState.IsValid)
            {
                db.UserMilestones.Add(userMilestone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserInfoes, "ID", "UserID", userMilestone.UserID);
            return View(userMilestone);
        }

        // GET: UserMilestones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMilestone userMilestone = db.UserMilestones.Find(id);
            if (userMilestone == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserInfoes, "ID", "UserID", userMilestone.UserID);
            return View(userMilestone);
        }

        // POST: UserMilestones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Target,Date")] UserMilestone userMilestone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMilestone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserInfoes, "ID", "UserID", userMilestone.UserID);
            return View(userMilestone);
        }

        // GET: UserMilestones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMilestone userMilestone = db.UserMilestones.Find(id);
            if (userMilestone == null)
            {
                return HttpNotFound();
            }
            return View(userMilestone);
        }

        // POST: UserMilestones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMilestone userMilestone = db.UserMilestones.Find(id);
            db.UserMilestones.Remove(userMilestone);
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
