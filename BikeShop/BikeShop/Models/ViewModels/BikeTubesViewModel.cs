using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class BikeTubesViewModel
    {
        public int SERIALNUMBER { get; set; }
        public string TUBENAME { get; set; }
        public Nullable<int> TUBEID { get; set; }
        public Nullable<int> LENGTH { get; set; }
    }
}