using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.DAL
{
    public class SurveySqlDal:ISurveySqlDal
    {
       // private const string SQL_GetParks = @"SELECT parkName, parkCode FROM park";
       private const string SQL_GetSurveyResults =
           @"SELECT survey_result.parkCode, parkName, count(survey_result.parkCode) as numberOfVotes 
                                                    FROM survey_result 
                                                    JOIN park ON park.parkCode = survey_result.parkCode
                                                    GROUP BY survey_result.parkCode, parkName 
                                                    ORDER BY numberOfVotes DESC;";
        private const string SQL_SaveNewSurvey = @"INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) 
                                                  VALUES (@parkCode, @emailAddress, @state, @activityLevel)";

        private readonly string connectionString;


        public SurveySqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //public List<SelectListItem> GetParkSelectList()
        //{
        //    List<SelectListItem> parkList = new List<SelectListItem>();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();


        //        SqlCommand command = new SqlCommand(SQL_GetParks, connection);
        //        var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            parkList.Add(MaptToRowPark(reader));
        //        }
        //    }
        //    return parkList;

        //}

        //private SelectListItem MaptToRowPark(SqlDataReader reader)
        //{
        //    return new SelectListItem()
        //    {
        //        Value = Convert.ToString(reader["parkCode"]),
        //        Text = Convert.ToString(reader["parkName"])
        //    };
        //}

        public List<DailySurvey> GetSurveyResults()
        {
            List<DailySurvey> results = new List<DailySurvey>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(SQL_GetSurveyResults, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    DailySurvey survey = new DailySurvey()
                    {
                        ParkCode = Convert.ToString(reader["parkCode"]),
                        ParkName = Convert.ToString(reader["parkName"]),
                        SurveyVote = Convert.ToInt32(reader["numberOfVotes"])
                    };
                    results.Add(survey);
                }
                return results;
            }

        }

        public void SaveSurvey(DailySurvey survey)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(SQL_SaveNewSurvey, connection);
                cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                cmd.Parameters.AddWithValue("@state", survey.State);
                cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                cmd.ExecuteNonQuery();
            }

        }

    }
}
