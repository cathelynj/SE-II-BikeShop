using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class PurchaseItemViewModel
    {
        [Key]
        public int PURCHASEID { get; set; }
        [Key]
        public int COMPONENTID { get; set; }
        public Nullable<decimal> PRICEPAID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<int> QUANTITYRECEIVED { get; set; }
    }
}