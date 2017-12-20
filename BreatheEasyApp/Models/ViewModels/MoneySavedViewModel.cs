using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreatheEasyApp.Models.ViewModels
{
    public class MoneySavedViewModel
    {
        public MoneySavedViewModel()
        {
            
        }

        public MoneySavedViewModel(UserInfo UserInfo)
        {
            StartDate = UserInfo.StartDate;
            PricePerPack = UserInfo.PricePerPack;
            CigsPerDay = UserInfo.CigsPerDay;
        }

        public int CigsPerDay { get; set; }

        public decimal PricePerPack { get; set; }

        public DateTime StartDate { get; set; }

        
    }
}