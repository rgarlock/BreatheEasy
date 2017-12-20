using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreatheEasyApp.Models.ViewModels
{
    public class CigsNotSmokedViewModel
    {
        public CigsNotSmokedViewModel()
        {
            
        }

        public CigsNotSmokedViewModel(UserInfo UserInfo)
        {
            StartDate = UserInfo.StartDate;
            CigsPerDay = UserInfo.CigsPerDay;
        }

        public int CigsPerDay { get; set; }

        public DateTime StartDate { get; set; }

     
    }
}