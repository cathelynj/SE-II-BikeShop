using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class ComponentNameViewModel
    {
        [Key]
        public string COMPONENTNAME1 { get; set; }
        public Nullable<int> ASSEMBLYORDER { get; set; }
        public string DESCRIPTION { get; set; }
    }
}