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
    
    public partial class BICYCLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BICYCLE()
        {
            this.BIKEPARTS = new HashSet<BIKEPART>();
            this.BICYCLETUBEUSAGEs = new HashSet<BICYCLETUBEUSAGE>();
            this.BIKETUBES = new HashSet<BIKETUBE>();
        }
    
        public int SERIALNUMBER { get; set; }
        public Nullable<int> CUSTOMERID { get; set; }
        public string MODELTYPE { get; set; }
        public Nullable<int> PAINTID { get; set; }
        public Nullable<int> FRAMESIZE { get; set; }
        public Nullable<System.DateTime> ORDERDATE { get; set; }
        public Nullable<System.DateTime> STARTDATE { get; set; }
        public Nullable<System.DateTime> SHIPDATE { get; set; }
        public Nullable<int> SHIPEMPLOYEE { get; set; }
        public Nullable<decimal> FRAMEASSEMBLER { get; set; }
        public Nullable<decimal> PAINTER { get; set; }
        public string CONSTRUCTION { get; set; }
        public Nullable<decimal> WATERBOTTLEBRAZEONS { get; set; }
        public string CUSTOMNAME { get; set; }
        public string LETTERSTYLEID { get; set; }
        public Nullable<int> STOREID { get; set; }
        public Nullable<int> EMPLOYEEID { get; set; }
        public Nullable<int> TOPTUBE { get; set; }
        public Nullable<int> CHAINSTAY { get; set; }
        public Nullable<int> HEADTUBEANGLE { get; set; }
        public Nullable<int> SEATTUBEANGLE { get; set; }
        public Nullable<decimal> LISTPRICE { get; set; }
        public Nullable<decimal> SALEPRICE { get; set; }
        public Nullable<decimal> SALESTAX { get; set; }
        public string SALESTATE { get; set; }
        public Nullable<decimal> SHIPPRICE { get; set; }
        public Nullable<decimal> FRAMEPRICE { get; set; }
        public Nullable<decimal> COMPONENTLIST { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual LETTERSTYLE LETTERSTYLE { get; set; }
        public virtual MODELTYPE MODELTYPE1 { get; set; }
        public virtual PAINT PAINT { get; set; }
        public virtual RETAILSTORE RETAILSTORE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIKEPART> BIKEPARTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BICYCLETUBEUSAGE> BICYCLETUBEUSAGEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIKETUBE> BIKETUBES { get; set; }
    }
}
