using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class BikePartsViewModel
    {
        [Key]
        public int SERIALNUMBER { get; set; }
        [Key]
        public int COMPONENTID { get; set; }
        public Nullable<int> SUBSTITUTEID { get; set; }
        public string LOCATION { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<System.DateTime> DATEINSTALLED { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
    }
}