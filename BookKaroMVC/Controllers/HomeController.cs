using BookKaroMVC.Models;
using BookKaroMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookKaroMVC.Controllers
{
    public class HomeController : Controller
    {

        private BookKaroEntities1 db = new BookKaroEntities1();
        //
        // GET: /Home/
        public ActionResult Index()
        {
          
            //ViewBag.Categories = new SelectList(db.tblCategories,"CategoryID", "CategoryName");
            //ViewBag.Areas = new SelectList(db.tblAreas, "AreaCode", "AreaDescription", "AreaCode");

            var ddlHomeSearch = new HomeViewModel   ();
            ddlHomeSearch.Areas = new SelectList(db.tblAreas, "AreaCode", "AreaDescription");
            

            ddlHomeSearch.Events = new SelectList(db.tblCategories, "CategoryID", "CategoryName", "CategoryID");
           
            ViewBag.Guests = new List<SelectListItem> {                  
                 new SelectListItem { Text = "100 or more", Value = "100"},                   
                 new SelectListItem { Text = "200 or more", Value = "200"},
                 new SelectListItem { Text = "300 or more", Value = "300"}, 
                 new SelectListItem { Text = "400 or more", Value = "400"}, 
                 new SelectListItem { Text = "500 or more", Value = "500"},
                 new SelectListItem { Text = "600 or more", Value = "600"},
                 new SelectListItem { Text = "700 or more", Value = "700"},
                 new SelectListItem { Text = "800 or more", Value = "800"},
                 new SelectListItem { Text = "900 or more", Value = "900"},
                 new SelectListItem { Text = "1000 or more", Value = "1000"},

             };
            return View(ddlHomeSearch);
        }

        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        //[HttpGet]
        //public ActionResult Search(HomeViewModel HomeViewModel)
        //{

        //    DateTime date = HomeViewModel.Date;

        //    int area = HomeViewModel.LocationID;
        //    int eventType = HomeViewModel.EventID;
        //    var SearchResults = (from v in db.tblVendors
        //                         join c in db.tblCategories on v.CategoryID equals c.CategoryID
        //                         join a in db.tblAreas on v.AreaCode equals a.AreaCode

        //                         where a.AreaCode == area && c.CategoryID == eventType
        //                         select new SearchResultsViewModel() { CategoryName = c.CategoryName, VendorName = v.VendorName, PriceRangeMinimum = v.VendorPriceRangeMinimum, AreaName = a.AreaDescription, CapacityMinimum = v.VendorCapacityMinimum });




        //    return View(SearchResults);
        //}


        [HttpGet]
        public ActionResult Search()
        {
            //var SearchCriteria = new HomeViewModel();
            //SearchCriteria.LocationID = ;


            int? eventType;
          
            //var SearchResults = (from v in db.tblVendors
            //                    join c in db.tblCategories on v.CategoryID equals c.CategoryID
            //                    join a in db.tblAreas on v.AreaCode equals a.AreaCode

            //                    where a.AreaCode == area && c.CategoryID == eventType
            //                     select new SearchResultsViewModel() {CategoryName = c.CategoryName,VendorName= v.VendorName,PriceRangeMinimum = v.VendorPriceRangeMinimum,AreaName= a.AreaDescription, CapacityMinimum = v.VendorCapacityMinimum });

            //SearchResults


            return View();
        }
    }
}
