using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;

namespace Capstone.Web.DAL
{
    public class SurveySqlDal:ISurveySqlDal

    {
        private readonly string connectionString;


        public SurveySqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
