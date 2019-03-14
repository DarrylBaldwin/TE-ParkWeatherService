using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Capstone.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        
        private IParkSqlDal parkDAL;
        private IForecastSqlDal forecastDAL;

        public HomeController(IParkSqlDal parkDAL, IForecastSqlDal forecastDAL)
        {
            this.parkDAL = parkDAL;
            this.forecastDAL = forecastDAL;
        }
    
        public IActionResult Index()
        {
            List<Park> parks = parkDAL.GetParks();
            return View(parks);
        }

        [HttpGet]
        public IActionResult Detail(string parkCode)
        {
            bool temp = UnitPreference();

            Park park = parkDAL.GetParkDetail(parkCode);
            park.Forecast = forecastDAL.Get5DayForecast(parkCode, temp);

            return View("Detail",park);
        }

       

        void GetWeather(string parkCode)
        {

            Park park = parkDAL.GetParkDetail(parkCode);         
        }

        [HttpGet]
        public IActionResult PreferFahrenheit(string parkCode)
        {
            HttpContext.Session.Set("UnitPreference", "F");
            return RedirectToAction("Detail", "Home", new { parkCode = parkCode }, null);
            
        }

        [HttpGet]
        public IActionResult PreferCelsius(string parkCode)
        {
            HttpContext.Session.Set("UnitPreference", "C");
            string temp = HttpContext.Session.GetString("UnitPreference");
            return RedirectToAction("Detail", "Home", new { parkCode = parkCode }, null);
        }

        private bool UnitPreference()
        {
            bool isFahrenheit;
            string temp = HttpContext.Session.Get<string>("UnitPreference");
            string blah = HttpContext.Session.GetString("UnitPreference");
            if (temp == "F" || string.IsNullOrEmpty(temp))
            {
                isFahrenheit = true;
            }
            else 
            {
                isFahrenheit = false;
            }
            
            return isFahrenheit;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }


      
  
    }//class
}//namespace
