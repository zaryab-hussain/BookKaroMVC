using BookKaroMVC.Models;
using BookKaroMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookKaroMVC.Controllers
{
    public class VendorController : Controller
    {
        private BookKaroEntities1 db = new BookKaroEntities1();
        //
        // GET: /Vendor/
        public ActionResult Index()
        {
            var vendor = db.tblVendors.ToList();
           
            return View(vendor);
        }

        //
        // GET: /Vendor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Vendor/Create
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
        // GET: /Vendor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Vendor/Edit/5
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
        // GET: /Vendor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Vendor/Delete/5
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

        [HttpGet]
        public ActionResult Search(int Areas, int Guests, int Events, DateTime tbxDatePicker)
        {
            //var SearchCriteria = new HomeViewModel();
            //SearchCriteria.LocationID = ;


            int? eventType;

            var SearchResults = (from v in db.tblVendors
                                 join c in db.tblCategories on v.CategoryID equals c.CategoryID
                                 join a in db.tblAreas on v.AreaCode equals a.AreaCode
                                 where a.AreaCode == Areas && c.CategoryID == Events
                                 select new SearchResultsViewModel() { CategoryName = c.CategoryName, VendorName = v.VendorName, PriceRangeMinimum = v.VendorPriceRangeMinimum, AreaName = a.AreaDescription, CapacityMinimum = v.VendorCapacityMinimum, ImageSource = v.VendorImageSource });

            //SearchResults


            return View(SearchResults);
        }



        [HttpGet]
        public ActionResult Detail(int VendorCode)
        
        {
            //var SearchCriteria = new HomeViewModel();
            //SearchCriteria.LocationID = ;


            var objVendorDetail = new VendorDetailViewModel();

            objVendorDetail = (from v in db.tblVendors
                                 join c in db.tblCategories on v.CategoryID equals c.CategoryID
                                 join a in db.tblAreas on v.AreaCode equals a.AreaCode
                                 join f in db.tblFacilities on v.FacilityID equals f.FacilityID
                                 where v.VendorID == VendorCode
                                 select new VendorDetailViewModel() 
                                 { Category = c.CategoryName,
                                   VendorName = v.VendorName,
                                   VendorPriceRangeMinimum = v.VendorPriceRangeMinimum,
                                   VendorPriceRangeMaximum = v.VendorPriceRangeMaximum,
                                   VendorCapacityMinimum = v.VendorCapacityMinimum,
                                   VendorCapacityMaximum = v.VendorCapacityMaximum,
                                   VendorDescription = v.VendorDescription,
                                   Area = a.AreaDescription,
                                   Facility = f.FacilityName,
                                   VendorAddress = v.VendorAddress,
                                   VendorImageSource = v.VendorImageSource
                                   
                                  
                                   
                                 }).SingleOrDefault();



            return View(objVendorDetail);
        }
    }
}
