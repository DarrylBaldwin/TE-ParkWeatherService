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
            List<DailySurvey> surveys = surveyDAL.GetParkSurveyResults();
            return View(surveys);
        }

        [HttpGet]
        public IActionResult AddSurvey()
        {
            DailySurvey survey = new DailySurvey();
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSurvey(DailySurvey survey)
        {
            surveyDAL.SaveSurvey(survey);
            return RedirectToAction("Index", "Survey");
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
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
            new SelectListItem { Value = "active", Text = "Active"  },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "sedentary", Text = "Sedentary" },
        };
    }
}