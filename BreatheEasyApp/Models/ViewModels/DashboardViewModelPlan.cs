using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BreatheEasyApp.Models.ViewModels
{
    public class DashboardViewModelPlan
    {
        public DashboardViewModelPlan()
        {

        }
        public DashboardViewModelPlan(UserMilestone UserMilestone)
        {
            ID = UserMilestone.ID;
            UserID = UserMilestone.UserID;
            Target = UserMilestone.Target;
            Date = UserMilestone.Date;


        }

        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int Target { get; set; }

        public int UserID { set; get; }

        //public int GetCigsAllowed(int ID, DateTime date, int target)
        //{
        //    if (DateTime.Today == date)
        //    {
        //        return target;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}