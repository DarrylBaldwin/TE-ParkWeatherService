using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.DAL.Interfaces
{
    public interface ISurveySqlDal
    {
       // List<SelectListItem> GetParkSelectList();
        List<DailySurvey> GetSurveyResults();
        void SaveSurvey(DailySurvey survey);
    }
}
