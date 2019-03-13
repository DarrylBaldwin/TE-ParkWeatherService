using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;

namespace Capstone.Web.Models
{
    public class Forecast
    {
        ParkCode                                     //parkCode
       
            
            
       // Day1                                        //fiveDayForecastValue
       public  int LowforDay1 { get; set; } //TODO derived based on F/C flag //low
       public int HighforDay1 { } //TODO derived based on F/C flag                                       //high
       public stringforDay1 ForecastDescription { get; set; }                        //forecast
       public string  ForecastAdvice { get; set; } //derived based on Forecast //TODO ForecastAdvice
       public  string TemperatureAdvice { get; set; } // derived based on temperature //TODO TemperatureAdvice

       public int LowforDay2 { get; set; } //TODO derived based on F/C flag //low
       public int HighforDay2 { } //TODO derived based on F/C flag                                       //high
       public string ForecastDescriptionforDay2 { get; set; }                        //forecast

       public int LowforDay3 { get; set; } //TODO derived based on F/C flag //low
       public int HighforDay3 { } //TODO derived based on F/C flag                                       //high
       public string ForecastDescriptionforDay3 { get; set; }                        //forecast

       public int LowforDay3 { get; set; } //TODO derived based on F/C flag //low
       public int HighforDay3 { } //TODO derived based on F/C flag                                       //high
       public string ForecastDescription { get; set; }                        //forecast

       public int Low { get; set; } //TODO derived based on F/C flag //low
       public int High { } //TODO derived based on F/C flag                                       //high
       public string ForecastDescription { get; set; }                        //forecast





    }
}
