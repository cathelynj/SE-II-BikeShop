using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class BicycleTubeUsageViewModel
    {
        public int SERIALNUMBER { get; set; }
        public int TUBEID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
    }
}