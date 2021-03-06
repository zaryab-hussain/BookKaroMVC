﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookKaroMVC.ViewModels
{
    public class SearchResultsViewModel
    {
        public int VendorID { get; set; }

        public string CategoryName { get; set; }

        public string VendorName { get; set; }

        public int PriceRangeMinimum { get; set; }

        public int PriceRangeMaximum { get; set; }

        public string AreaName { get; set; }

        public string CapacityMinimum { get; set; }

        public string CapacityMaximum { get; set; }
        public string ImageSource { get; set; }

        public int Guests { get; set; }

    }
}