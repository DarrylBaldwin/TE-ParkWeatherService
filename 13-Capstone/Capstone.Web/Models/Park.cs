using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
      public String ParkCode { get; set; } //parkCode
      public  String        Name{get; set;}  // parkName
      public  String        State{get; set;}  //state
      public  int           Acreage{get; set;} //acreage
      public  int           ElevationInFeet {get; set;}  //elevationInFeet
      public  int           MilesOfTrail{get; set;}   //milesOfTrail
      public  int           NumberOfCampsites{get; set;}  //numberOfCampsites
      public  string        Climate{get; set;}  //climate
      public  string        ParkDescripton{get; set;}  //parkDescription
      public  int           YearFounded{get; set;}  //yearFounded
      public  int           AnnualVisitorCount{get; set;}  //annualVisitorCount
      public  String        Quote {get; set;} //inspirationalQuote
      public  String        QuoteSource{get; set;}  //inspirationalQuoteSource
      public  int           EntryFee{get; set;}  //entryFee
      public  int           NumberOfAnimalSpecies{get; set;}  //numbeOfAnimalSpecies
      public List<Forecast> Forecast { get; set; }
      public string Image
      {
          get
          {
             string location = @"/images/parks/" + ParkCode + ".jpg";
              
             return location;
          }
       }  //derived

        
    }
}



