using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class CityViewModel
    {
        public int CityID { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string AreaCode { get; set; }
        public Nullable<int> Population1990 { get; set; }
        public Nullable<int> Population1980 { get; set; }
        public string Country { get; set; }
        public Nullable<int> Latitude { get; set; }
        public Nullable<int> Longitude { get; set; }
        public Nullable<int> PopulationCDF { get; set; }
    }
}