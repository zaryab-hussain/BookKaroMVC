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
    
    public partial class tblService
    {
        public tblService()
        {
            this.tblVendors = new HashSet<tblVendor>();
        }
    
        public int ServiceID { get; set; }
        public string ServiceDescription { get; set; }
    
        public virtual ICollection<tblVendor> tblVendors { get; set; }
    }
}