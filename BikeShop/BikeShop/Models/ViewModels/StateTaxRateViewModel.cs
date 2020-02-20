using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class StateTaxRateViewModel
    {
        [Key]
        public string STATE { get; set; }
        public Nullable<decimal> TAXRATE { get; set; }
    }
}