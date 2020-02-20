using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class BicycleTubeUsageViewModel
    {
        [Key]
        public int SERIALNUMBER { get; set; }
        [Key]
        public int TUBEID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
    }
}