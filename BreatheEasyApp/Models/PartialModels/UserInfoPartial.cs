using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace BreatheEasyApp.Models
{
    public partial class UserInfo
    {
        private void SetPlan(DateTime startDate, Plan plan, int cigsPerDay)
        {
            this.StartDate = startDate;
            this.FinalQuitDate = startDate.AddDays(plan.Duration);
            this.Plan = plan;
            this.PlanID = plan.ID;
            this.CigsPerDay = cigsPerDay;

        }

        public void SetPlan(BreatheEasyEntities db, DateTime startDate, int planId, int cigsPerDay)
        {
            var plan = db.Plans.Find(planId);
            SetPlan(startDate, plan, cigsPerDay);
            SetUserMilestones(db);
        }

        private void SetUserMilestones(BreatheEasyEntities db)
        {
            if (this.UserMilestones == null)
            {
                UserMilestones = new List<UserMilestone>();
            }

            UserMilestones.Clear();
            if (Plan.Duration > 0)
            {
                for (int days = 0; days <= Plan.Duration; days++)
                {
                    var milestoneDate = StartDate.AddDays(days);
                    int target = CigsPerDay * (Plan.Duration - days) / Plan.Duration;
                    var milestone = new UserMilestone()
                    {
                        Date = milestoneDate,
                        Target = target,

                    };

                    UserMilestones.Add(milestone);
                }
            }
            else
            {
                UserMilestones.Add(new UserMilestone {Date = DateTime.Today, Target = 0});
            }

        }

        public decimal GetMoneySaved()
        {
            decimal result = UserMilestones.Where(s => s.Date <= DateTime.Now)
                .Sum(p => CigsPerDay - p.Target);

            var quitDate = UserMilestones.OrderBy(s => s.Date).First(s => s.Target == 0).Date;

            if (quitDate < DateTime.Now)
            {
                result += (DateTime.Now - quitDate).Days;

            }

            result *= PricePerPack/20;


            return Decimal.Round(result, 2);
            ;
        }

        public int CigsNotSmoked()
        {
            int result = UserMilestones.Where(s => s.Date <= DateTime.Now)
                .Sum(p => CigsPerDay - p.Target);

            var quitDate = UserMilestones.OrderBy(s => s.Date).First(s => s.Target == 0).Date;

            if (quitDate < DateTime.Now)
            {
                result += (DateTime.Now - quitDate).Days;
            }

            return result;
        }

        
    
    }
}
