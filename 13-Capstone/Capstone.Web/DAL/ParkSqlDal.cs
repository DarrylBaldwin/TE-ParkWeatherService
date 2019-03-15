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
    public class ParkSqlDal : IParkSqlDal
    {

        private readonly string connectionString;
        private const string SQL_GetParkDetail = @"SELECT * FROM park WHERE parkCode = @parkCode";
        private const string SQL_GetParks = @"SELECT * FROM park";
        

        public ParkSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Park GetParkDetail(string parkCode)
        {
            Park park = new Park();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_GetParkDetail, connection);
                command.Parameters.AddWithValue("@parkCode", parkCode);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                   park = MaptToRowPark(reader);

                }
            }

            return park;
        }

        public List<Park> GetParks()
        {
            List<Park> parkList = new List<Park>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_GetParks, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    parkList.Add(MaptToRowPark(reader));

                }
            }
            return parkList;
        }

        private Park MaptToRowPark(SqlDataReader reader)
        {
            return new Park()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                Name = Convert.ToString(reader["parkName"]), // parkName
                State = Convert.ToString(reader["state"]), //state
                Acreage = Convert.ToInt32(reader["acreage"]), //acreage
                ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]), //elevationInFeet
                MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]), //milesOfTrail
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]), //numberOfCampsites
                Climate = Convert.ToString(reader["climate"]), //climate
                ParkDescripton = Convert.ToString(reader["parkDescription"]), //parkDescription
                YearFounded = Convert.ToInt32(reader["yearFounded"]), //yearFounded
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]), //annualVisitorCount
                Quote = Convert.ToString(reader["inspirationalQuote"]), //inspirationalQuote
                QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]), //inspirationalQuoteSource
                EntryFee = Convert.ToInt32(reader["entryFee"]), //entryFee
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]), //numbeOfAnimalSpecies

            };
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








    }//class

}//namespace