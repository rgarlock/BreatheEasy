using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BreatheEasyApp.Models;
using BreatheEasyApp.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BreatheEasyApp.Controllers
{
    public class UserInfoesController : Controller
    {
        private BreatheEasyEntities db = new BreatheEasyEntities();
        private ApplicationUserManager _userManager;

        public UserInfoesController()
        {
            
        }

        public UserInfoesController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
          
        }
      

        // GET: UserInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.PlanID = new SelectList(db.Plans, "ID", "Name");
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Name,Email,PricePerPack,CigsPerDay,StartDate,FinalQuitDate,PlanID")] UserInfo userInfo)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                userInfo.UserID = user.Id;
                db.UserInfoes.Add(userInfo);
           
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", userInfo.UserID);
            ViewBag.PlanID = new SelectList(db.Plans, "ID", "Name", userInfo.PlanID);

            var userInfoVm = new UserInfoViewModel(userInfo);

            return View(userInfoVm);
        }

        // GET: UserInfoes/Edit/5
        [Authorize]
        public ActionResult Edit()
        {
             var userId = User.Identity.GetUserId();

            UserInfo userInfo = db.UserInfoes.Single(p => p.UserID == userId);
           
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", userInfo.UserID);
            ViewBag.PlanID = new SelectList(db.Plans, "ID", "Name", userInfo.PlanID);
            return View(userInfo);
        }

        // POST: UserInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Email,PricePerPack, GoalItem, GoalPrice")] UserInfo userInfo) /*CigsPerDay,StartDate,FinalQuitDate,PlanID*/
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                UserInfo CurrentUser = db.UserInfoes.Single(p => p.UserID == userId);
                CurrentUser.Name = userInfo.Name;
                CurrentUser.Email = userInfo.Email;
                CurrentUser.PricePerPack = userInfo.PricePerPack;
                CurrentUser.GoalItem = userInfo.GoalItem;
                CurrentUser.GoalPrice = userInfo.GoalPrice;
                db.Entry(CurrentUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Home");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", userInfo.UserID);
            ViewBag.PlanID = new SelectList(db.Plans, "ID", "Name", userInfo.PlanID);
            return View(userInfo);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

    }
}
