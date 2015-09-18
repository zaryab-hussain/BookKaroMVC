using BookKaroMVC.Models;
using BookKaroMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookKaroMVC.Controllers
{
    public class LocationController : Controller
    {
        private BookKaroEntities2 db = new BookKaroEntities2();
        //
        // GET: /Vendor/
        [HttpGet]
        public ActionResult Index(int? Areas, int? Events)
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
        public ViewResult Search(string Date, string Areas, string Events, string Guests)
        {
            //var SearchCriteria = new HomeViewModel();
            //SearchCriteria.LocationID = ;


            int AreaCode = (string.Equals(Areas, "")) ? 0 : Convert.ToInt32(Areas);
            int EventCode = (string.Equals(Events, "")) ? 0 : Convert.ToInt32(Events);
            int NoOfGuests = (string.Equals(Guests, "")) ? 0 : Convert.ToInt32(Guests);
            int? eventType;

            var SearchResults = (from v in db.tblVendors
                                 from vendorCategory in v.tblCategories
                                 join Category in db.tblCategories on vendorCategory.CategoryID equals Category.CategoryID
                                 join a in db.tblAreas on v.AreaCode equals a.AreaCode
                                 where a.AreaCode == AreaCode && Category.CategoryID == EventCode
                                 select new SearchResultsViewModel() { CategoryName = Category.CategoryName, VendorName = v.VendorName, PriceRangeMinimum = v.VendorPriceRangeMinimum, AreaName = a.AreaDescription, CapacityMinimum = v.VendorCapacityMinimum, ImageSource = v.VendorImageSource });




            return View(SearchResults);
        }



        [HttpGet]
        public ActionResult Detail(int id)
        {
            //var SearchCriteria = new HomeViewModel();
            //SearchCriteria.LocationID = ;

            int VendorCode = Convert.ToInt32(id);

            var objVendorDetail = new VendorDetailViewModel();

            objVendorDetail = (from vendor in db.tblVendors

                               from vendorCategory in vendor.tblCategories
                               join category in db.tblCategories on vendorCategory.CategoryID equals category.CategoryID
                               join a in db.tblAreas on vendor.AreaCode equals a.AreaCode

                               //join i in db.tblImages on v.VendorID equals i.VendorID
                               where vendor.VendorID == VendorCode
                               select new VendorDetailViewModel()
                               {
                                   Category = vendorCategory.CategoryName,
                                   VendorName = vendor.VendorName,
                                   VendorPriceRangeMinimum = vendor.VendorPriceRangeMinimum,
                                   VendorPriceRangeMaximum = vendor.VendorPriceRangeMaximum,
                                   VendorCapacityMinimum = vendor.VendorCapacityMinimum,
                                   VendorCapacityMaximum = vendor.VendorCapacityMaximum,
                                   VendorDescription = vendor.VendorDescription,
                                   Area = a.AreaDescription,
                                   VendorAddress = vendor.VendorAddress



                               }).SingleOrDefault();

            List<string> ImageSources = (from vendor in db.tblVendors
                                         from vendorImages in vendor.tblImages
                                         where vendorImages.VendorID == VendorCode
                                         select vendorImages.ImageDetail).ToList();

            List<string> Facilites = (from vendor in db.tblVendors

                                      from vendorFacility in vendor.tblFacilities
                                      join facility in db.tblFacilities on vendorFacility.FacilityID equals facility.FacilityID

                                      where vendor.VendorID == VendorCode

                                      select facility.FacilityName).ToList();

            objVendorDetail.Facility = Facilites;
            objVendorDetail.VendorImageSource = ImageSources;



            return View(objVendorDetail);
        }
    }
}
