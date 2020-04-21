using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class PreferenceViewModel
    {
        [Key]
        public string ItemName { get; set; }
        public Nullable<int> Value { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateChanged { get; set; }
    }
}