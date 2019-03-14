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
            Park park = parkDAL.GetParkDetail(parkCode);
            park.Forecast = forecastDAL.Get5DayForecast(parkCode, UnitPreference());

            return View("Detail",park);
        }

       

        void GetWeather(string parkCode)
        {

            Park park = parkDAL.GetParkDetail(parkCode);         
        }


        public void PreferFahrenheit()
        {
            HttpContext.Session.Set("UnitPreference", "F");
            
        }

        public void PreferCelsius()
        {
            HttpContext.Session.SetString("UnitPreference", "C");
        }

        private bool UnitPreference()
        {
            bool isFahrenheit;

            if ((HttpContext.Session.GetString("UnitPreference") == "F") || (HttpContext.Session.GetString("UnitPreference") == null))
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
