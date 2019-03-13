using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}