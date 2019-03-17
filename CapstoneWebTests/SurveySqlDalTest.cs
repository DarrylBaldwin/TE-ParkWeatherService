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
    public class SurveySqlDalTest
    {
        private TransactionScope transaction;

        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog = NPGeek; Integrated Security = True";

        int surveyCount = 0;


        [TestInitialize]
        public void Initialize()
        {
            transaction = new TransactionScope();
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //make  3 test parks
                    const string SQL_MakeTestPark = @"INSERT park VALUES('TEST', 'Test National Park', 'Ohio', 32832, 696, 125, 0, 'Woodland', 2000, 2189849, 'Of all the paths you take... ', 'John Muir', 'Though a short distance from the urban areas....', 8, 760);";
                    SqlCommand command = new SqlCommand(SQL_MakeTestPark, connection);
                    command.ExecuteNonQuery();

                    const string SQL_MakeTestParkII = @"INSERT park VALUES('TESTII', 'TEST National Park', 'Florida', 1508538, 0, 35, 0, 'Tropical', 1934, 1110901, 'There are no other Everglades..', 'Marjory Stoneman Douglas', 'The Florida Everglades...', 8, 760);";
                    command = new SqlCommand(SQL_MakeTestParkII, connection);
                    command.ExecuteNonQuery();

                    const string SQL_MakeTestParkI = @"INSERT park VALUES('TESTI', 'Test National Park', 'Ohio', 32832, 696, 125, 0, 'Woodland', 2000, 2189849, 'Of all the paths you take... ', 'John Muir', 'Though a short distance from the urban areas....', 8, 760);";
                    command = new SqlCommand(SQL_MakeTestParkI, connection);
                    command.ExecuteNonQuery();

                    //make a survey for TEST park
                    const string SQL_MakeSurvey = @"INSERT survey_result (parkCode, emailAddress, state, activityLevel) VALUES ('TEST', 'TEST@TEST.COM', 'HI', 'inactive');";
                    command = new SqlCommand(SQL_MakeSurvey, connection);
                    command.ExecuteNonQuery();

                    //make a survey for TESTII
                    const string SQL_MakeSurveyII = @"INSERT survey_result (parkCode, emailAddress, state, activityLevel) VALUES ('TESTII', 'TEST@TEST.COM', 'HI', 'inactive');";
                    command = new SqlCommand(SQL_MakeSurveyII, connection);
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
        public void GetSurveyResultsTest()
        {
            SurveySqlDal dal = new SurveySqlDal(connectionString);
            List<DailySurvey> surveys = dal.GetSurveyResults();

            Assert.IsTrue(surveys.Any(i => i.ParkCode == "TESTII"));
            Assert.IsTrue(surveys.Any(i => i.ParkCode == "TEST"));
            Assert.IsFalse(surveys.Any(i => i.ParkCode == "TESTI"));
            Assert.IsTrue(surveys.Count >= 2);

        }

        [TestMethod()]
        public void SaveSurvey()
        {
            SurveySqlDal dal = new SurveySqlDal(connectionString);
            List<DailySurvey> surveys = dal.GetSurveyResults();
            surveyCount = surveys.Count();

            DailySurvey survey = new DailySurvey();
            survey.ParkCode = "TESTI";
            survey.ActivityLevel = "sedentary";
            survey.EmailAddress = "test@test.com";
            survey.State = "HI";
            dal.SaveSurvey(survey);

            surveys = dal.GetSurveyResults();
            Assert.IsTrue(surveyCount + 1 == surveys.Count());
            Assert.IsTrue(surveys.Any(i => i.ParkCode == "TESTI"));

        }
    }
}
