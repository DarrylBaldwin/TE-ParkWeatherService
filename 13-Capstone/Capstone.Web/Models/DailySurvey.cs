using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DailySurvey
    {   
        public string ParkCode { get; set; }  //parkCode
        public string EmailAddress { get; set; }  //emailAddress
        public string State {get;set;} //state
        public string ActivityLevel { get; set;} //activityLevel
        public int SurveyVote { get; set; }


    }
}
