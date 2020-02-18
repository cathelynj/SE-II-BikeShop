using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class PurchaseItemViewModel
    {
        public int PURCHASEID { get; set; }
        public int COMPONENTID { get; set; }
        public Nullable<decimal> PRICEPAID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<int> QUANTITYRECEIVED { get; set; }
    }
}