using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class ManufactorerTransactionViewModel
    {
        public int MANUFACTURERID { get; set; }
        public System.DateTime TRANSACTIONDATE { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public int REFERENCE { get; set; }
    }
}