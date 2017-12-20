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
    public class HealthFactMilestonesController : Controller
    {
        private BreatheEasyEntities db = new BreatheEasyEntities();

        // GET: HealthFactMilestones
        public ActionResult Index()
        {
            var healthFactMilestones = db.HealthFactMilestones;
            return View(healthFactMilestones.ToList());
        }

        // GET: HealthFactMilestones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthFactMilestone healthFactMilestone = db.HealthFactMilestones.Find(id);
            if (healthFactMilestone == null)
            {
                return HttpNotFound();
            }
            return View(healthFactMilestone);
        }

        // GET: HealthFactMilestones/Create
        public ActionResult Create()
        {
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "ContentType");
            return View();
        }

        // POST: HealthFactMilestones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DaysIn,FactBody,ImageID")] HealthFactMilestone healthFactMilestone)
        {
            if (ModelState.IsValid)
            {
                db.HealthFactMilestones.Add(healthFactMilestone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(healthFactMilestone);
        }

        // GET: HealthFactMilestones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthFactMilestone healthFactMilestone = db.HealthFactMilestones.Find(id);
            if (healthFactMilestone == null)
            {
                return HttpNotFound();
            }
            
            return View(healthFactMilestone);
        }

        // POST: HealthFactMilestones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DaysIn,FactBody,ImageID")] HealthFactMilestone healthFactMilestone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthFactMilestone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(healthFactMilestone);
        }

        // GET: HealthFactMilestones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthFactMilestone healthFactMilestone = db.HealthFactMilestones.Find(id);
            if (healthFactMilestone == null)
            {
                return HttpNotFound();
            }
            return View(healthFactMilestone);
        }

        // POST: HealthFactMilestones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthFactMilestone healthFactMilestone = db.HealthFactMilestones.Find(id);
            db.HealthFactMilestones.Remove(healthFactMilestone);
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
