using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace CapstoneWebTests
{
    [TestClass]
    public class ForecastSqlDalTest
    {
        private TransactionScope transaction;

        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog = NPGeek; Integrated Security = True";

        [TestInitialize]
        public void Initialize()
        {
            transaction = new TransactionScope();
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Test Park
                    const string SQL_MakeTestPark = @"INSERT park VALUES('TEST', 'Test National Park', 'Ohio', 32832, 696, 125, 0, 'Woodland', 2000, 2189849, 'Of all the paths you take... ', 'John Muir', 'Though a short distance from the urban areas....', 8, 760);";
                    SqlCommand command = new SqlCommand(SQL_MakeTestPark, connection);
                    command.ExecuteNonQuery();

                    //make 5 day forecast for test park
                    const string SQL_MakeForecastDay1 = @"INSERT weather (parkCode, fiveDayForecastValue, low, high, forecast) VALUES('TEST', 1, 32, 51, 'partly cloudy')";
                    command = new SqlCommand(SQL_MakeForecastDay1, connection);
                    command.ExecuteNonQuery();

                    const string SQL_MakeForecastDay2 = @"INSERT weather (parkCode, fiveDayForecastValue, low, high, forecast) VALUES('TEST', 2, 42, 72, 'sunny')";
                    command = new SqlCommand(SQL_MakeForecastDay2, connection);
                    command.ExecuteNonQuery();

                    const string SQL_MakeForecastDay3 = @"INSERT weather (parkCode, fiveDayForecastValue, low, high, forecast) VALUES('TEST', 3, 26, 41, 'thunderstorms')";
                    command = new SqlCommand(SQL_MakeForecastDay3, connection);
                    command.ExecuteNonQuery();

                    const string SQL_MakeForecastDay4 = @"INSERT weather (parkCode, fiveDayForecastValue, low, high, forecast) VALUES('TEST', 4, 40, 52, 'rain')";
                    command = new SqlCommand(SQL_MakeForecastDay4, connection);
                    command.ExecuteNonQuery();

                    const string SQL_MakeForecastDay5 = @"INSERT weather (parkCode, fiveDayForecastValue, low, high, forecast) VALUES('TEST', 5, 14, 21, 'snow')";
                    command = new SqlCommand(SQL_MakeForecastDay5, connection);
                    command.ExecuteNonQuery();
                }
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod()]
        public void Get5DayForecastTest()
        {
            ForecastSqlDal dal = new ForecastSqlDal(connectionString);
            List<Forecast> forecasts = dal.Get5DayForecast("TEST", true);

            Assert.IsTrue(forecasts.Any(i => i.ParkCode == "TEST"));
            Assert.IsTrue(forecasts.Count == 5);
            Assert.IsFalse(forecasts.Any(i => i.TemperatureAdvice == null));
            Assert.IsFalse(forecasts.Any(i => i.TemperatureAdvice == "Pack Snowshoes"));
        }
    }
}
