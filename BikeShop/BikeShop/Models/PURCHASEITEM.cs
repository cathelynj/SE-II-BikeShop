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
    
    public partial class PURCHASEITEM
    {
        public int PURCHASEID { get; set; }
        public int COMPONENTID { get; set; }
        public Nullable<decimal> PRICEPAID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<int> QUANTITYRECEIVED { get; set; }
    
        public virtual COMPONENT COMPONENT { get; set; }
        public virtual PURCHASEORDER PURCHASEORDER { get; set; }
    }
}
