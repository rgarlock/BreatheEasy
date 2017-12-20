using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BreatheEasyApp.Models;
using BreatheEasyApp.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace BreatheEasyApp.Controllers
{
    public class DashboardController : Controller
    {
        BreatheEasyEntities db = new BreatheEasyEntities();

        // GET: Dashboard
        [Authorize]
        public ActionResult ShowCurrentMilestone()
        {
            var userId = User.Identity.GetUserId();

            UserInfo CurrentUser = db.UserInfoes.Single(p => p.UserID == userId);

            UserMilestone UserMilestone =  db.UserMilestones
                .Where(s => s.UserID == CurrentUser.ID && s.Date <= DateTime.Now )
                .OrderByDescending(s => s.Date)
                .First();

           

            var DashboardPlanvm = new DashboardViewModelPlan(UserMilestone);
            var Dashboardvm = new DashboardViewModel{Plan = DashboardPlanvm};

            
            
              
            return View(Dashboardvm);
            
            
            
            
        }
    }
}