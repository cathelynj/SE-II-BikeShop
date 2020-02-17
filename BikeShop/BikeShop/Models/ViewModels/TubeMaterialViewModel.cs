using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class TubeMaterialViewModel
    {
        public int TUBEID { get; set; }
        public string MATERIAL { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<int> DIAMETER { get; set; }
        public Nullable<int> THICKNESS { get; set; }
        public string ROUNDNESS { get; set; }
        public Nullable<int> WEIGHT { get; set; }
        public Nullable<int> STIFFNESS { get; set; }
        public Nullable<decimal> LISTPRICE { get; set; }
        public string CONSTRUCTION { get; set; }
    }
}