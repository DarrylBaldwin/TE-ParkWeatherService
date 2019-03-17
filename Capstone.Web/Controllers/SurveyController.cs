using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Capstone.Web.Extensions;
namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveySqlDal surveyDAL;
        private IParkSqlDal parkDAL;

        public SurveyController(ISurveySqlDal surveyDAL, IParkSqlDal parkDAL)
        {
            this.surveyDAL = surveyDAL;
            this.parkDAL = parkDAL;
        }


        public IActionResult Index()
        {
            List<DailySurvey> surveys = surveyDAL.GetSurveyResults();
            return View(surveys);
        }

        [HttpGet]
        public IActionResult AddSurvey()
        {
            DailySurvey survey = new DailySurvey();
            DailySurveyViewModel model = new DailySurveyViewModel
            {
                SelectActivityLevelsList = ActivityLevels,
                SelectParkList = ParkSelectList(),
                SelectStatesList = States,
                Survey = survey
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSurvey(DailySurveyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                surveyDAL.SaveSurvey(model.Survey);
                return RedirectToAction("Index", "Survey");
            }
        }

        public static List<SelectListItem> ActivityLevels = new List<SelectListItem>()
        {
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "extremely active", Text = "Extremely Active"  }
        };

        public static List<SelectListItem> States = new List<SelectListItem>()
        {
                    new SelectListItem { Text = "Alabama" },
                    new SelectListItem { Text = "Alaska" },
                    new SelectListItem { Text = "Arizona" },
                    new SelectListItem { Text = "Arkansas" },
                    new SelectListItem { Text = "California" },
                    new SelectListItem { Text = "Colorado" },
                    new SelectListItem { Text = "Connecticut" },
                    new SelectListItem { Text = "Delaware" },
                    new SelectListItem { Text = "Florida" },
                    new SelectListItem { Text = "Georgia" },
                    new SelectListItem { Text = "Hawaii" },
                    new SelectListItem { Text = "Idaho" },
                    new SelectListItem { Text = "Illinois" },
                    new SelectListItem { Text = "Indiana" },
                    new SelectListItem { Text = "Iowa" },
                    new SelectListItem { Text = "Kansas" },
                    new SelectListItem { Text = "Kentucky" },
                    new SelectListItem { Text = "Louisiana" },
                    new SelectListItem { Text = "Maine" },
                    new SelectListItem { Text = "Maryland" },
                    new SelectListItem { Text = "Massachusetts" },
                    new SelectListItem { Text = "Michigan" },
                    new SelectListItem { Text = "Minnesota" },
                    new SelectListItem { Text = "Mississippi" },
                    new SelectListItem { Text = "Missouri" },
                    new SelectListItem { Text = "Montana" },
                    new SelectListItem { Text = "North Carolina" },
                    new SelectListItem { Text = "North Dakota" },
                    new SelectListItem { Text = "Nebraska" },
                    new SelectListItem { Text = "Nevada" },
                    new SelectListItem { Text = "New Hampshire" },
                    new SelectListItem { Text = "New Jersey" },
                    new SelectListItem { Text = "New Mexico" },
                    new SelectListItem { Text = "New York" },
                    new SelectListItem { Text = "Ohio" },
                    new SelectListItem { Text = "Oklahoma" },
                    new SelectListItem { Text = "Oregon" },
                    new SelectListItem { Text = "Pennsylvania" },
                    new SelectListItem { Text = "Rhode Island" },
                    new SelectListItem { Text = "South Carolina" },
                    new SelectListItem { Text = "South Dakota" },
                    new SelectListItem { Text = "Tennessee" },
                    new SelectListItem { Text = "Texas" },
                    new SelectListItem { Text = "Utah" },
                    new SelectListItem { Text = "Vermont" },
                    new SelectListItem { Text = "Virginia" },
                    new SelectListItem { Text = "Washington" },
                    new SelectListItem { Text = "West Virginia" },
                    new SelectListItem { Text = "Wisconsin" },
                    new SelectListItem { Text = "Wyoming" }
                };

        public List<SelectListItem> ParkSelectList()
        {
            List<Park> parks = parkDAL.GetParks();
            List<SelectListItem> results = new List<SelectListItem>();

            foreach (Park park in parks)
            {
                results.Add(new SelectListItem(park.Name, park.ParkCode));
            }

            return results;
        }

    }//class
}//namespace