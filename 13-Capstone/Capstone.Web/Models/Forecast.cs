using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Web.Models
{
    public class Forecast
    {
        public string ParkCode { get; set; } //parkCode
        public int Low { get; set; } //low
        public int High { get; set; } //high
        public bool InFahrenheit { get; set; } = true;//TODO figure out session and how this would work.
        public string DisplayLow {
            get
            {
                if (InFahrenheit)
                {
                    return Low + " degrees fahrenheit";
                }
                else //celsius
                {
                    double celsius = ((double)Low - 32) * 5 /9;
                    return celsius + " degrees celsius";
                }


            }
        }

        public string DisplayHigh
        {

            get
            {
                if (InFahrenheit)
                {
                    return High + " degrees fahrenheit";
                }
                else //celsius
                {
                    double celsius = ((double)High - 32) * 5 / 9;
                    return celsius + " degrees celsius";
                }


            }



        }
        public string ForecastDescription { get; set; } //forecast
        public int Day { get; set; }

        public string ForecastAdvice
        {
            get
            {
                string msg = "";
                if (Day == 1 && ForecastDescription == "snow"
                ) //assumes only lowercase and only forecast snow, rain, partly cloudy, thunderstorm, sunny
                {
                    msg = "Pack snowshoes!";
                }

                if (Day == 1 && ForecastDescription == "rain")
                {
                    msg = "Pack rain gear and waterproof shoes!";

                }

                if (Day == 1 && ForecastDescription == "sunny")
                {
                    msg = "Pack sunscreen.";
                }

                if (Day == 1 && ForecastDescription == "thunderstorms")
                {
                    msg = "Seek shelter and avoid hiking on exposed ridges!!";
                }

                return msg;
            }
        }

        public string Image
        {
            get { return ("\\images\\weather\\" + (ForecastDescription.Replace(" ", string.Empty)) + ".png"); }

        }


        public string TemperatureAdvice
        {
            get
            {
                string msg = "";
                if (Day == 1 && High >= 75)
                {
                    msg = "Bring an extra gallon of water.";

                }

                if (Day == 1 && High - Low >= 20) //assuming low is always less than == to high
                {
                    msg = "Wear breathable layers.";
                }

                if (Day == 1 && Low <= 20) //assuming low is always less than == to high
                {
                    msg =
                        "Danger: frigid temperatures can cause hypothermia.  If not treated quickly, hypothermia can cause severe health problems, including death. Heart problems. Cold weather can increase your risk of a heart attack. When you're outside in the cold, your heart works harder to keep you warm — leading to increased heart rate and blood pressure.";
                }

                return msg;
            }
        }


    }//class
}//namespace
