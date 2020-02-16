using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public int CityID { get; set; }
        public Nullable<decimal> BalanceDue { get; set; }
    }
}