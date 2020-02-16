using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class CityViewModel
    {
        public int CITYID { get; set; }
        public string ZIPCODE { get; set; }
        public string CITY1 { get; set; }
        public string STATE { get; set; }
        public string AREACODE { get; set; }
        public Nullable<int> POPULATION1990 { get; set; }
        public Nullable<int> POPULATION1980 { get; set; }
        public string COUNTRY { get; set; }
        public Nullable<int> LATITUDE { get; set; }
        public Nullable<int> LONGITUDE { get; set; }
        public Nullable<int> POPULATIONCDF { get; set; }
    }
}