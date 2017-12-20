using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BreatheEasyApp.Models.ViewModels
{
    public class GoalViewModel
    {

        public string GoalItem { get; set; }

        [DataType(DataType.Currency)]
        public decimal? AmountRemaining { get; set; }
        
    }
}