using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class PaintViewModel
    {
        public int PaintID { get; set; }
        public string ColorName { get; set; }
        public string ColorStyle { get; set; }
        public string ColorList { get; set; }
        public Nullable<System.DateTime> DateIntroduced { get; set; }
        public Nullable<System.DateTime> DateDiscontinued { get; set; }
    }
}