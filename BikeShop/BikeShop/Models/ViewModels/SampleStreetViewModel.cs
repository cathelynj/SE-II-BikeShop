using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class SampleStreetViewModel
    {
        [Key]
        public int ID { get; set; }
        public string BASEADDRESS { get; set; }
    }
}