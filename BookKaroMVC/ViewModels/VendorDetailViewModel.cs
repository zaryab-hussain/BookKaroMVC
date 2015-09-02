using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookKaroMVC.ViewModels
{
    public class VendorDetailViewModel
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorPriceRangeMinimum { get; set; }
        public string VendorCapacityMinimum { get; set; }
        public string VendorPriceRangeMaximum { get; set; }
        public int MembershipDescription { get; set; }
        public string VendorAddress { get; set; }
        public string VendorCapacityMaximum { get; set; }
       public string Area { get; set; }
        public string Category { get; set; }
   
        public string VendorImageSource { get; set; }

        public string Facility { get; set; }

        public string VendorDescription { get; set; }
        public string VendorCity { get; set; }
        public string VendorCountry { get; set; }
    }
}