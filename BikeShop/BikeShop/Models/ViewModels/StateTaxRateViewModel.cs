using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class StateTaxRateViewModel
    {
        public string STATE { get; set; }
        public Nullable<decimal> TAXRATE { get; set; }
    }
}