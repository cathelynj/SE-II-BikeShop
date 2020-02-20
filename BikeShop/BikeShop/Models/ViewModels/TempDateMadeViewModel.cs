using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class TempDateMadeViewModel
    {
        [Key]
        public System.DateTime DATEVALUE { get; set; }
        public Nullable<int> MADECOUNT { get; set; }
    }
}