using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
      public String ParkCode { get; set; } //parkCode
      public  String        Name{get; set;}  // parkName

      [Display(Name = "State:")]
      public  String        State{get; set;}  //state

      [Display(Name = "Acres:")]
      public  int           Acreage{get; set;} //acreage

      [Display(Name = "Elevation (in feet):")]
      public  int           ElevationInFeet {get; set;}  //elevationInFeet

      [Display(Name = "Miles of Trail:")]
      public  int           MilesOfTrail{get; set;}   //milesOfTrail

      [Display(Name = "Number of Campsites:")]
      public  int           NumberOfCampsites{get; set;}  //numberOfCampsites

      [Display(Name = "Climate:")]
      public  string        Climate{get; set;}  //climate

      [Display(Name = "Description:")]
      public  string        ParkDescription{get; set;}  //parkDescription

      [Display(Name = "Year Founded:")]
      public  int           YearFounded{get; set;}  //yearFounded

      [Display(Name = "Annual Visitors:")]
      public  int           AnnualVisitorCount{get; set;}  //annualVisitorCount

      [Display(Name = "Inspirational Quote:")]
      public  String        Quote {get; set;} //inspirationalQuote

      [Display(Name = "Quote Source:")]
      public  String        QuoteSource{get; set;}  //inspirationalQuoteSource

      [Display(Name = "Entry Fee:")]
      public  int           EntryFee{get; set;}  //entryFee

      [Display(Name = "Number of Animal Species:")]
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



