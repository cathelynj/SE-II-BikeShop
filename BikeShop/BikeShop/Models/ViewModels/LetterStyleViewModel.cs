using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class LetterStyleViewModel
    {
        [Key]
        public string LetterStyle1 { get; set; }
        public string Description { get; set; }
    }
}