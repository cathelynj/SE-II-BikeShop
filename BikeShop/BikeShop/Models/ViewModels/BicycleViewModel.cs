using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class BicycleViewModel
    {
        public int SerialNumber { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string ModelType { get; set; }
        public Nullable<int> PaintID { get; set; }
        public Nullable<int> FrameSize { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public Nullable<int> ShipEmployee { get; set; }
        public Nullable<decimal> FrameAssembler { get; set; }
        public Nullable<decimal> Painter { get; set; }
        public string Construction { get; set; }
        public Nullable<decimal> WaterBottleBrazeOns { get; set; }
        public string CustomName { get; set; }
        public string LetterstyleID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> TopTube { get; set; }
        public Nullable<int> ChainStay { get; set; }
        public Nullable<int> HeadTubeAngle { get; set; }
        public Nullable<int> SeaTubeAngle { get; set; }
        public Nullable<decimal> ListPrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<decimal> SalesTax { get; set; }
        public string SalesState { get; set; }
        public Nullable<decimal> ShipPrice { get; set; }
        public Nullable<decimal> FramePrice { get; set; }
        public Nullable<decimal> ComponentList { get; set; }
    }
}