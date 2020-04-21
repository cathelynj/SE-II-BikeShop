using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class WorkAreaViewModel
    {
        [Key]
        public string WORKAREA1 { get; set; }
        public string DESCRIPTION { get; set; }
    }
}