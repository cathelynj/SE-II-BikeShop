using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.Models.ViewModels
{
    public class RevisionHistoryViewModel
    {
        public int ID { get; set; }
        public string VERSION { get; set; }
        public Nullable<System.DateTime> CHANGEDATE { get; set; }
        public string NAME { get; set; }
        public string REVISIONCOMMENTS { get; set; }
    }
}