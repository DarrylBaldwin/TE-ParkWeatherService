using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;

namespace Capstone.Web.Models
{
    public class Forecast
    {
       public string ParkCode { get; set; }                                     //parkCode
       public int Low { get; set; }                //low
       public int High { get; set; }              //high
       public string ForecastDescriptionForDay1  { get; set; }                        //forecast
       public string  ForecastAdvice { get; set; } 
       public  string TemperatureAdvice { get; set; } 
  

    }
}
