using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class BikePartsViewModel
    {
        public int SERIALNUMBER { get; set; }
        public int COMPONENTID { get; set; }
        public Nullable<int> SUBSTITUTEID { get; set; }
        public string LOCATION { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<System.DateTime> DATEINSTALLED { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
    }
}