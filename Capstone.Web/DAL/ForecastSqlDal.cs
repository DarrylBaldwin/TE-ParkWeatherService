using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ForecastSqlDal : IForecastSqlDal
    {
        private readonly string connectionString;
        private const string SQL_Get5DayForecast = @" Select TOP 5 * From weather WHERE parkCode = @parkCode ORDER BY fiveDayForecastValue";


        public ForecastSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Forecast> Get5DayForecast(string parkCode, bool isFahrenheit)
        {
             List<Forecast> results = new List<Forecast>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_Get5DayForecast, connection);
                command.Parameters.AddWithValue("@parkCode", parkCode);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Forecast forecast = MapToRowForecast(reader,isFahrenheit);
                    results.Add(forecast);
                }
            }

            return results;
        }

        private Forecast MapToRowForecast(SqlDataReader reader, bool isFahrenheit)
        {
            Forecast forecast = new Forecast()
            {
                IsFahrenheit = isFahrenheit,
                ParkCode = Convert.ToString(reader["parkCode"]), //parkCode
                Low = Convert.ToInt32(reader["low"]), //low
                High = Convert.ToInt32(reader["high"]), //high
                Day = Convert.ToInt32(reader["fiveDayForecastValue"]),
                ForecastDescription = Convert.ToString(reader["forecast"])
            };
            return forecast;
        }



    }//class

}//namespace
