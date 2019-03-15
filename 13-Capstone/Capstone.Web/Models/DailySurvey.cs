using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DailySurvey
    {     
        public string ParkCode { get; set; }  //parkCode

        //[Required]
        [Display(Name = "Choose Your Favorite Park")]
        public string ParkName { get; set; }

        [Display (Name = "Email Address")]
        [Required]
        [DataType (DataType.EmailAddress)]
        public string EmailAddress { get; set; }  //emailAddress

        [Display(Name = "State of Residence")]
        [Required]
        public string State {get;set;} //state

        [Display(Name = "Choose Your Level of Activity")]
        [Required]
        public string ActivityLevel { get; set;} //activityLevel
        public int SurveyVote { get; set; }


    }
}
