using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookKaroMVC.ViewModels
{
    public class HomeViewModel
    {
        public string CategoryName { get; set; }

        
        public string AreaDescription { get; set; }
        public int CategoryID { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<SelectListItem> Areas { get; set; }
        public int? AreaCode { get; set; }
        public IEnumerable<SelectListItem> Events { get; set; }

        public int? CategoryCode { get; set; }

      
    }
}