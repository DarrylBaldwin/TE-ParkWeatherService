using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;

namespace Capstone.Web.DAL
{
    public class ForecastSqlDal : IForecastSqlDal
    {
        private readonly string connectionString;


        public ForecastSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
