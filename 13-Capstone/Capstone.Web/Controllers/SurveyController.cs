using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveySqlDal surveyDAL;

        public SurveyController(ISurveySqlDal surveyDAL)
        {
           this.surveyDAL = surveyDAL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Results()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Results(DailySurvey survey)
        {
            return View();
        }

        public static List<SelectListItem> ActivityLevels = new List<SelectListItem>()
        {
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "extremely active", Text = "Extremely Active"  }
        };
    }
}