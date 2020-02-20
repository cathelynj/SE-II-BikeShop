using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class ManufactorerViewModel
    {
        [Key]
        public int MANUFACTURERID { get; set; }
        public string MANUFACTURERNAME { get; set; }
        public string CONTACTNAME { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public string ZIPCODE { get; set; }
        public Nullable<int> CITYID { get; set; }
        public Nullable<decimal> BALANCEDUE { get; set; }
    }
}