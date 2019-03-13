using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySqlDal:ISurveySqlDal

    {
        private readonly string connectionString;


        public SurveySqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public List<Park> GetParkSurveyResults()
        {
            List<Park> results = new List<Park>();
            //get list add to results, update properties of each park returned for Park.SurveyVote
            return results;

        }
    }
}
