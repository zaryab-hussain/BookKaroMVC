using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookKaroMVC.ViewModels
{
    public class SearchResultsViewModel
    {
        public string CategoryName { get; set; }

        public string VendorName { get; set; }

        public string PriceRangeMinimum { get; set; }

        public string AreaName { get; set; }

        public string CapacityMinimum { get; set; }
        public string ImageSource { get; set; }

    }
}