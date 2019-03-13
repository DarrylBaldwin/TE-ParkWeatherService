using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL.Interfaces
{
    public interface IForecastSqlDal
    {


        List<Forecast> Get5DayForecast(string parkCode);

    }

    }
