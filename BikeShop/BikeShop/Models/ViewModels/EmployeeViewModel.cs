using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string TaxpayerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string HomePhone { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<System.DateTime> DateHired { get; set; }
        public Nullable<System.DateTime> DateReleased { get; set; }
        public Nullable<int> CurrentManager { get; set; }
        public Nullable<int> SalaryGrade { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Title { get; set; }
        public string Workarea { get; set; }
    }
}