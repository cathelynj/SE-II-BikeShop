using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class GroupOViewModel
    {
        public int ComponentGroupID { get; set; }
        public string GroupName { get; set; }
        public string BikeType { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> EndYear { get; set; }
        public Nullable<decimal> Weight { get; set; }
    }
}