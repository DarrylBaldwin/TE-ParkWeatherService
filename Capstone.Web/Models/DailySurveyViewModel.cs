using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DailySurveyViewModel
    {
        public List<SelectListItem> SelectParkList { get; set; }
        public List<SelectListItem> SelectStatesList { get; set; }
        public List<SelectListItem> SelectActivityLevelsList { get; set; }
        public DailySurvey Survey { get; set; }
    }
}
