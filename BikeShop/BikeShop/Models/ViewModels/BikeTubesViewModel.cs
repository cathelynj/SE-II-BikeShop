using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class BikeTubesViewModel
    {
        [Key]
        public int SERIALNUMBER { get; set; }
        [Key]
        public string TUBENAME { get; set; }
        public Nullable<int> TUBEID { get; set; }
        public Nullable<int> LENGTH { get; set; }
    }
}