//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookKaroMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblVendor
    {
        public tblVendor()
        {
            this.tblBookingItems = new HashSet<tblBookingItem>();
            this.tblImages = new HashSet<tblImage>();
            this.tblCategories = new HashSet<tblCategory>();
        }
    
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorPriceRangeMinimum { get; set; }
        public string VendorCapacityMinimum { get; set; }
        public string VendorEnteredOn { get; set; }
        public string VendorEnteredBy { get; set; }
        public string VendorUpdatedOn { get; set; }
        public string VendorUpdatedBy { get; set; }
        public string VendorPriceRangeMaximum { get; set; }
        public int MembershipID { get; set; }
        public string VendorAddress { get; set; }
        public string VendorCapacityMaximum { get; set; }
        public int UserID { get; set; }
        public int AreaCode { get; set; }
        public int FacilityID { get; set; }
        public int CategoryID { get; set; }
        public string VendorImageSource { get; set; }
        public string VendorDescription { get; set; }
    
        public virtual tblArea tblArea { get; set; }
        public virtual ICollection<tblBookingItem> tblBookingItems { get; set; }
        public virtual tblFacility tblFacility { get; set; }
        public virtual ICollection<tblImage> tblImages { get; set; }
        public virtual tblMembership tblMembership { get; set; }
        public virtual tblUser tblUser { get; set; }
        public virtual ICollection<tblCategory> tblCategories { get; set; }
        public virtual tblCategory tblCategory { get; set; }
    }
}
