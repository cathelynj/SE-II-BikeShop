using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int EMPLOYEEID { get; set; }
        public string TAXPAYERID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string HOMEPHONE { get; set; }
        public string ADDRESS { get; set; }
        public string ZIPCODE { get; set; }
        public Nullable<int> CITYID { get; set; }
        public Nullable<System.DateTime> DATEHIRED { get; set; }
        public Nullable<System.DateTime> DATERELEASED { get; set; }
        public Nullable<int> CURRENTMANAGER { get; set; }
        public Nullable<int> SALARYGRADE { get; set; }
        public Nullable<decimal> SALARY { get; set; }
        public string TITLE { get; set; }
        public string WORKAREA { get; set; }
    }
}