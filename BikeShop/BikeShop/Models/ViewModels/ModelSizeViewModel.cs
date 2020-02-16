using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class ModelSizeViewModel
    {
        public string MODELTYPE { get; set; }
        public int MSIZE { get; set; }
        public Nullable<int> TOPTUBE { get; set; }
        public Nullable<int> CHAINSTAY { get; set; }
        public Nullable<int> TOTALLENGTH { get; set; }
        public Nullable<int> GROUNDCLEARANCE { get; set; }
        public Nullable<int> HEADTUBEANGLE { get; set; }
        public Nullable<int> SEATTUBEANGLE { get; set; }
    }
}