using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class ComponentViewModel
    {
        public int COMPONENTID { get; set; }
        public Nullable<int> MANUFACTURERID { get; set; }
        public string PRODUCTNUMBER { get; set; }
        public string ROAD { get; set; }
        public string CATEGORY { get; set; }
        public Nullable<int> LENGTH { get; set; }
        public Nullable<int> HEIGHT { get; set; }
        public Nullable<int> WIDTH { get; set; }
        public Nullable<int> WEIGHT { get; set; }
        public Nullable<int> YEAR { get; set; }
        public Nullable<int> ENDYEAR { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<decimal> LISTPRICE { get; set; }
        public Nullable<decimal> ESTIMATEDCOST { get; set; }
        public Nullable<int> QUANTITYONHAND { get; set; }
    }
}