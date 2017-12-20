using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreatheEasyApp.Models.ViewModels
{
    public class HeathFactViewModel
    {
        public TimeSpan DaysIn { get; set; }
        public string FactBody { get; set; }
        public bool IsPassed { get; set; }
    }
}