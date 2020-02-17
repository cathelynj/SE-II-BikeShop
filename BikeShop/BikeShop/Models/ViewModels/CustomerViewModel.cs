using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int CUSTOMERID { get; set; }
        public string PHONE { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string ZIPCODE { get; set; }
        public int CITYID { get; set; }
        public Nullable<decimal> BALANCEDUE { get; set; }
    }
}