using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using BreatheEasyApp.HelperClasses;

namespace BreatheEasyApp.Models.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardViewModelPlan Plan { get; set; }
        public List<Image> Badges { get; set; }
        public decimal MoneySaved { get; set; }
        public List<Craving> Cravings { get; set; }
        public int CigsNotSmoked { get; set; }
        public GoalViewModel Goal { get; set; }
        public List<HeathFactViewModel> HealthFacts { get; set; }
        public QuoteContent Quote { get; set; }
      
    }
}