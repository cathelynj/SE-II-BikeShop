using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class PurchaseOrderViewModel
    {
        [Key]
        public int PURCHASEID { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
        public Nullable<int> MANUFACTURERID { get; set; }
        public Nullable<decimal> TOTALLIST { get; set; }
        public Nullable<decimal> SHIPPINGCOST { get; set; }
        public Nullable<decimal> DISCOUNT { get; set; }
        public Nullable<System.DateTime> ORDERDATE { get; set; }
        public Nullable<System.DateTime> RECEIVEDATE { get; set; }
        public Nullable<decimal> AMOUNTDUE { get; set; }
    }
}