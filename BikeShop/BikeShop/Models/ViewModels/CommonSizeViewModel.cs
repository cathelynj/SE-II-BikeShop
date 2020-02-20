using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class CommonSizeViewModel
    {
        [Key]
        public string MODELTYPE { get; set; }
        [Key]
        public int FRAMESIZE { get; set; }
    }
}