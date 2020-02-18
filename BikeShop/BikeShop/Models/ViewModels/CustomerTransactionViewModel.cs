using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class CustomerTransactionViewModel
    {
        [Key]
        public int CUSTOMERID { get; set; }
        [Key]
        public System.DateTime TRANSACTIONDATE { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
        public string EMPLOYEEFIRST { get; set; }
        public string EMPLOYEELAST { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<int> REFERENCE { get; set; }

        //public virtual CUSTOMER CUSTOMER { get; set; }]
        public List<CUSTOMER> CustomerList { get; set; }
    }
}