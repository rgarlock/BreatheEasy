using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;

namespace BreatheEasyApp.Models.ViewModels
{
    public class UserInfoViewModel
    {

        public UserInfoViewModel()
        {

        }

        public UserInfoViewModel(UserInfo UserInfo)
        {
            ID = UserInfo.ID;
            UserID = UserInfo.UserID;
            Name = UserInfo.Name;
            Email = UserInfo.Email;
            PricePerPack = UserInfo.PricePerPack;
            CigsPerDay = UserInfo.CigsPerDay;
            StartDate = UserInfo.StartDate;
            FinalQuitDate = UserInfo.FinalQuitDate;
            GoalItem = UserInfo.GoalItem;
            GoalPrice = UserInfo.GoalPrice;
            PlanID = UserInfo.PlanID;
        }

        public decimal? GoalPrice { get; set; }

        public string GoalItem { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        public string UserID { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price-Per-Pack")]
        public decimal PricePerPack { get; set; }

        [Display(Name = "Cigarettes Smoked Daily")]
        public int CigsPerDay { get; set; }

        [Display(Name = "Start Date")]
        public System.DateTime StartDate { get; set; }

        [Display(Name = "Final Quit Date")]
        public Nullable<System.DateTime> FinalQuitDate { get; set; }

        [Display(Name = "Select Quitting Plan")]
        public int PlanID { get; set; }


        public UserInfo ToUserInfo()
        {
            UserInfo UserInfo = new UserInfo();

            UserInfo.ID = ID;
            UserInfo.UserID = UserID;
            UserInfo.Name = Name;
            UserInfo.Email = Email;
            UserInfo.PricePerPack = PricePerPack;
            UserInfo.CigsPerDay = CigsPerDay;
            UserInfo.StartDate = StartDate;
            UserInfo.FinalQuitDate = FinalQuitDate;
            UserInfo.PlanID = PlanID;
            UserInfo.GoalItem = GoalItem;
            UserInfo.GoalPrice = GoalPrice;
            return UserInfo;
        }


    }
}

    
    




