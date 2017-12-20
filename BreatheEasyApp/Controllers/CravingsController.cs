using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BreatheEasyApp.Models;
using Microsoft.AspNet.Identity;

namespace BreatheEasyApp.Controllers
{
    [Authorize]
    public class CravingsController : Controller
    {
        private BreatheEasyEntities db = new BreatheEasyEntities();

     

    

        // GET: Cravings/Create
        
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UserInfoes, "ID", "UserID");
            Craving craving = new Craving();
            craving.DateTime = DateTime.Now;


            return View(craving);
        }

        // POST: Cravings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Comment,Intensity,DateTime")] Craving craving)
        {
           
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                UserInfo CurrentUser = db.UserInfoes.Single(p => p.UserID == userId);
                craving.UserInfo = CurrentUser;
                db.Cravings.Add(craving);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.UserID = new SelectList(db.UserInfoes, "ID", "UserID", craving.UserID);
            return View(craving);
        }

       

        // GET: Cravings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Craving craving = db.Cravings.Find(id);

            var userId = User.Identity.GetUserId();
            UserInfo CurrentUser = db.UserInfoes.Single(p => p.UserID == userId);
            if (craving == null || craving.UserID != CurrentUser.ID)
            {
                return HttpNotFound();
            }
            return View(craving);
        }

        // POST: Cravings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Craving craving = db.Cravings.Find(id);
            var userId = User.Identity.GetUserId();
            UserInfo CurrentUser = db.UserInfoes.Single(p => p.UserID == userId);
            if (craving == null || craving.UserID != CurrentUser.ID)
            {
                return HttpNotFound();
            }
            db.Cravings.Remove(craving);
            db.SaveChanges();
            return RedirectToAction("Dashboard","Home");
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
