using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BreatheEasyApp.HelperClasses;
using BreatheEasyApp.Models;
using BreatheEasyApp.Models.ViewModels;
using Microsoft.AspNet.Identity;
using RestSharp;

namespace BreatheEasyApp.Controllers
{
    public class HomeController : Controller
    {
        private BreatheEasyEntities db = new BreatheEasyEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Dashboard
        [Authorize]
        public ActionResult Dashboard()
        {
            var userId = User.Identity.GetUserId();

            UserInfo CurrentUser = db.UserInfoes.Single(p => p.UserID == userId);

            UserMilestone UserMilestone = db.UserMilestones
                .Where(s => s.UserID == CurrentUser.ID && s.Date <= DateTime.Now)
                .OrderByDescending(s => s.Date)
                .First();

            var DashboardPlanvm = new DashboardViewModelPlan(UserMilestone);
            var Dashboardvm = new DashboardViewModel { Plan = DashboardPlanvm };

            Dashboardvm.Badges = db.BadgeMilestones.OrderBy(p => p.DaysIn).AsEnumerable().Select(s =>
            {
                if (CurrentUser.StartDate.AddDays(s.DaysIn) < DateTime.Now)
                {
                    return s.ImageActive;
                }
                else
                {
                    return s.ImageInactive;
                }

            }).ToList();

            Dashboardvm.MoneySaved = CurrentUser.GetMoneySaved();

            Dashboardvm.Cravings = db.Cravings.Where(s => s.UserID == CurrentUser.ID).OrderByDescending(s => s.DateTime).ToList();

            Dashboardvm.CigsNotSmoked = CurrentUser.CigsNotSmoked();
            
            Dashboardvm.Goal = new GoalViewModel
            {
                AmountRemaining = CurrentUser.GoalPrice - Dashboardvm.MoneySaved,
                GoalItem = CurrentUser.GoalItem
            };

            var healthFacts = db.HealthFactMilestones.AsEnumerable().Select(x => new HeathFactViewModel
            {
                DaysIn = TimeSpan.FromDays((double) x.DaysIn),
                FactBody = x.FactBody,
                IsPassed = DateTime.Now - CurrentUser.StartDate > TimeSpan.FromDays((double) x.DaysIn)

            }).OrderBy(x => x.DaysIn);

            Dashboardvm.HealthFacts = healthFacts.ToList();

            Dashboardvm.Quote = QuoteApi.GetQod();
            

            return View(Dashboardvm);


         

        }

        public ActionResult GetApi()
        {
            var client = new RestClient("http://quotes.rest/qod.json");
            var request = new RestRequest("/", Method.GET);

            request.Parameters.Add(new Parameter { Name = "category", Value = "inspire", Type = ParameterType.QueryString });

            var response = client.Execute<QuoteResponse>(request);
            if (!response.IsSuccessful)
            {
                //Handle your errors
            }
            ViewBag.ResponseText = response.Content;
            return View(response.Data);

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