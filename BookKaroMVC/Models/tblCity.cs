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
    
    public partial class tblCity
    {
        public tblCity()
        {
            this.tblAreas = new HashSet<tblArea>();
        }
    
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityDescription { get; set; }
        public string CityRemarks { get; set; }
        public int CountryID { get; set; }
    
        public virtual ICollection<tblArea> tblAreas { get; set; }
        public virtual tblCountry tblCountry { get; set; }
    }
}