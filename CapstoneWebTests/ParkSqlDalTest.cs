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
    public class ParkSqlDalTest
    {
        private TransactionScope transaction;

        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog = NPGeek; Integrated Security = True";

        [TestInitialize]
        public void Intialize()
        {
            transaction = new TransactionScope();
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //make test parks
                    const string SQL_MakeTestPark = @"INSERT park VALUES('TEST', 'Test National Park', 'Ohio', 32832, 696, 125, 0, 'Woodland', 2000, 2189849, 'Of all the paths you take... ', 'John Muir', 'Though a short distance from the urban areas....', 8, 760);";
                    SqlCommand command = new SqlCommand(SQL_MakeTestPark, connection);
                    command.ExecuteNonQuery();

                    const string SQL_MakeTestParkII = @"INSERT park VALUES('TESTII', 'TEST National Park', 'Florida', 1508538, 0, 35, 0, 'Tropical', 1934, 1110901, 'There are no other Everglades..', 'Marjory Stoneman Douglas', 'The Florida Everglades...', 8, 760);";
                    command = new SqlCommand(SQL_MakeTestParkII, connection);
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
        public void GetParksTest()
        {
            ParkSqlDal dal = new ParkSqlDal(connectionString);
            List<Park> parks = dal.GetParks();

            Assert.IsTrue(parks.Any(i => i.ParkCode == "TEST"));
            Assert.IsTrue(parks.Any(i => i.Name == "Test National Park"));
            Assert.IsTrue(parks.Count >= 2);
        }

        [TestMethod()]
        public void GetParksDetailTest()
        {
            ParkSqlDal dal = new ParkSqlDal(connectionString);
            Park park = dal.GetParkDetail("TEST");

            Assert.IsNotNull(park.ParkCode);
            Assert.IsTrue(park.Name == "Test National Park");
            Assert.IsTrue(park.NumberOfAnimalSpecies == 760);
        }
    }
}
