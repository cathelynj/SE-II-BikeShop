//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BikeShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMERTRANSACTION
    {
        public int CUSTOMERID { get; set; }
        public System.DateTime TRANSACTIONDATE { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<int> REFERENCE { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
    }
}
