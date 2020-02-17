using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class CustomerTransactionViewModel
    {
        public int CUSTOMERID { get; set; }
        public System.DateTime TRANSACTIONDATE { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<int> REFERENCE { get; set; }
    }
}