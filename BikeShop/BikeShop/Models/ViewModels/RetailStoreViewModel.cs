using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class RetailStoreViewModel
    {
        public int STOREID { get; set; }
        public string STORENAME { get; set; }
        public string PHONE { get; set; }
        public string CONTACTFIRSTNAME { get; set; }
        public string CONTACTLASTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string ZIPCODE { get; set; }
        public Nullable<int> CITYID { get; set; }
    }
}