using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class ManufactorerTransactionViewModel
    {
        [Key]
        public int MANUFACTURERID { get; set; }
        [Key]
        public System.DateTime TRANSACTIONDATE { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        [Key]
        public int REFERENCE { get; set; }
    }
}