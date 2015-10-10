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

        //[HttpGet]
        //public ViewResult Search(string Date, string Areas, string Events, string Guests)
        //{
        //    //var SearchCriteria = new HomeViewModel();
        //    //SearchCriteria.LocationID = ;


        //    int AreaCode = (string.Equals(Areas, "")) ? 0 : Convert.ToInt32(Areas);
        //    int EventCode = (string.Equals(Events, "")) ? 0 : Convert.ToInt32(Events);
        //    int NoOfGuests = (string.Equals(Guests, "")) ? 0 : Convert.ToInt32(Guests);
        //    int? eventType;

        //    var SearchResults = (from v in db.tblVendors
        //                         from vendorCategory in v.tblCategories
        //                         join Category in db.tblCategories on vendorCategory.CategoryID equals Category.CategoryID
        //                         join a in db.tblAreas on v.AreaCode equals a.AreaCode
        //                         where a.AreaCode == AreaCode && Category.CategoryID == EventCode
        //                         select new SearchResultsViewModel() { CategoryName = Category.CategoryName, VendorName = v.VendorName, PriceRangeMinimum = v.VendorPriceRangeMinimum, AreaName = a.AreaDescription, CapacityMinimum = v.VendorCapacityMinimum,  CapacityMaximum = v.VendorCapacityMaximum, PriceRangeMaximum = v.VendorPriceRangeMaximum,ImageSource = v.VendorImageSource , VendorID = v.VendorID});




        //    return View(SearchResults);
        //}





        [HttpGet]
        public ViewResult Search(string Date, string Areas, string Events, string Guests, string Min, string Max)
        {
            //var SearchCriteria = new HomeViewModel();
            //SearchCriteria.LocationID = ;


            int AreaCode = (string.Equals(Areas, "")) ? 0 : Convert.ToInt32(Areas);
            int EventCode = (string.Equals(Events, "")) ? 0 : Convert.ToInt32(Events);
            int NoOfGuests = (string.Equals(Guests, "")) ? 0 : Convert.ToInt32(Guests);
            int minAmount = (string.Equals(Guests, "")) ? 0 : Convert.ToInt32(Min);
            int maxAmount = (string.Equals(Guests, "")) ? 0 : Convert.ToInt32(Max);
            ViewBag.NoOfGuest = NoOfGuests;
            //int serviceCode = Convert.ToInt32(serviceType);
            ViewBag.AreaCode = AreaCode;
            ViewBag.EventCode = EventCode;
            ViewBag.NoOfGuests = NoOfGuests;
            ViewBag.DateOfBooking = Date;
            if (string.IsNullOrEmpty(Min) || string.IsNullOrEmpty(Max))
            {
                var SearchResults = (from v in db.tblVendors
                                     from vendorCategory in v.tblCategories
                                     join Category in db.tblCategories on vendorCategory.CategoryID equals Category.CategoryID
                                     join a in db.tblAreas on v.AreaCode equals a.AreaCode
                                     where a.AreaCode == AreaCode && Category.CategoryID == EventCode 

                                     select new SearchResultsViewModel()
                                     {
                                         CategoryName = Category.CategoryName,
                                         VendorName = v.VendorName,
                                         PriceRangeMinimum = v.VendorPriceRangeMinimum,
                                         AreaName = a.AreaDescription,
                                         CapacityMinimum = v.VendorCapacityMinimum,
                                         CapacityMaximum = v.VendorCapacityMaximum,
                                         PriceRangeMaximum = v.VendorPriceRangeMaximum,
                                         ImageSource = v.VendorImageSource,
                                         VendorID = v.VendorID
                                     });
                return View(SearchResults);
            }
            else
            {
                //var SearchResults = (from v in db.tblVendors
                //                     from vendorService in v.tblServices
                //                     join service in db.tblServices on vendorService.ServiceID equals service.ServiceID
                //                     where service.ServiceID == serviceCode
                //                     select new SearchResultsViewModel()
                //                     {
                //                         VendorName = v.VendorName,
                //                         PriceRangeMinimum = v.VendorPriceRangeMinimum,
                //                         PriceRangeMaximum = v.VendorPriceRangeMaximum,
                //                         ImageSource = v.VendorImageSource,
                //                         VendorID = v.VendorID

                //                     });
                //return View(SearchResults);

                var SearchResults = (from v in db.tblVendors
                                     from vendorCategory in v.tblCategories
                                     join Category in db.tblCategories on vendorCategory.CategoryID equals Category.CategoryID
                                     join a in db.tblAreas on v.AreaCode equals a.AreaCode
                                     where a.AreaCode == AreaCode && Category.CategoryID == EventCode && (minAmount <= v.VendorPriceRangeMinimum && maxAmount >= v.VendorPriceRangeMaximum)

                                     select new SearchResultsViewModel()
                                     {
                                         CategoryName = Category.CategoryName,
                                         VendorName = v.VendorName,
                                         PriceRangeMinimum = v.VendorPriceRangeMinimum,
                                         AreaName = a.AreaDescription,
                                         CapacityMinimum = v.VendorCapacityMinimum,
                                         CapacityMaximum = v.VendorCapacityMaximum,
                                         PriceRangeMaximum = v.VendorPriceRangeMaximum,
                                         ImageSource = v.VendorImageSource,
                                         VendorID = v.VendorID
                                     });

                return View(SearchResults);

            }


        }



        [HttpGet]
        public PartialViewResult SearchPartial(string Date, string Areas, string Events, string Guests, string Min, string Max)
        {
            //var SearchCriteria = new HomeViewModel();
            //SearchCriteria.LocationID = ;


            int AreaCode = (string.Equals(Areas, "")) ? 0 : Convert.ToInt32(Areas);
            int EventCode = (string.Equals(Events, "")) ? 0 : Convert.ToInt32(Events);
            int NoOfGuests = (string.Equals(Guests, "")) ? 0 : Convert.ToInt32(Guests);
            int minAmount = (string.Equals(Guests, "")) ? 0 : Convert.ToInt32(Min);
            int maxAmount = (string.Equals(Guests, "")) ? 0 : Convert.ToInt32(Max);
            ViewBag.NoOfGuest = NoOfGuests;
            //int serviceCode = Convert.ToInt32(serviceType);
            ViewBag.AreaCode = AreaCode;
            ViewBag.EventCode = EventCode;
            ViewBag.NoOfGuests = NoOfGuests;
            ViewBag.DateOfBooking = Date;
            if (string.IsNullOrEmpty(Min) || string.IsNullOrEmpty(Max))
            {
                var SearchResults = (from v in db.tblVendors
                                     from vendorCategory in v.tblCategories
                                     join Category in db.tblCategories on vendorCategory.CategoryID equals Category.CategoryID
                                     join a in db.tblAreas on v.AreaCode equals a.AreaCode
                                     where a.AreaCode == AreaCode && Category.CategoryID == EventCode

                                     select new SearchResultsViewModel()
                                     {
                                         CategoryName = Category.CategoryName,
                                         VendorName = v.VendorName,
                                         PriceRangeMinimum = v.VendorPriceRangeMinimum,
                                         AreaName = a.AreaDescription,
                                         CapacityMinimum = v.VendorCapacityMinimum,
                                         CapacityMaximum = v.VendorCapacityMaximum,
                                         PriceRangeMaximum = v.VendorPriceRangeMaximum,
                                         ImageSource = v.VendorImageSource,
                                         VendorID = v.VendorID
                                     });
                return PartialView(SearchResults);
            }
            else
            {
                //var SearchResults = (from v in db.tblVendors
                //                     from vendorService in v.tblServices
                //                     join service in db.tblServices on vendorService.ServiceID equals service.ServiceID
                //                     where service.ServiceID == serviceCode
                //                     select new SearchResultsViewModel()
                //                     {
                //                         VendorName = v.VendorName,
                //                         PriceRangeMinimum = v.VendorPriceRangeMinimum,
                //                         PriceRangeMaximum = v.VendorPriceRangeMaximum,
                //                         ImageSource = v.VendorImageSource,
                //                         VendorID = v.VendorID

                //                     });
                //return View(SearchResults);

                var SearchResults = (from v in db.tblVendors
                                     from vendorCategory in v.tblCategories
                                     join Category in db.tblCategories on vendorCategory.CategoryID equals Category.CategoryID
                                     join a in db.tblAreas on v.AreaCode equals a.AreaCode
                                     where a.AreaCode == AreaCode && Category.CategoryID == EventCode && (minAmount <= v.VendorPriceRangeMinimum && maxAmount >= v.VendorPriceRangeMaximum)

                                     select new SearchResultsViewModel()
                                     {
                                         CategoryName = Category.CategoryName,
                                         VendorName = v.VendorName,
                                         PriceRangeMinimum = v.VendorPriceRangeMinimum,
                                         AreaName = a.AreaDescription,
                                         CapacityMinimum = v.VendorCapacityMinimum,
                                         CapacityMaximum = v.VendorCapacityMaximum,
                                         PriceRangeMaximum = v.VendorPriceRangeMaximum,
                                         ImageSource = v.VendorImageSource,
                                         VendorID = v.VendorID
                                     });

                return PartialView(SearchResults);

            }


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
                                   VendorAddress = vendor.VendorAddress,



                               }).SingleOrDefault();

            List<string> ImageSources = (from vendor in db.tblVendors
                                         from vendorImages in vendor.tblImages
                                         where vendorImages.VendorID == VendorCode
                                         select vendorImages.ImageDetail).ToList();
            

            List<string> Facilites = (from vendor in db.tblVendors

                                      from vendorFacility in vendor.tblFacilities
                                      join facility in db.tblFacilities on vendorFacility.FacilityID equals facility.FacilityID into  ps
                                      from facility in ps.DefaultIfEmpty()
                                      where vendor.VendorID == VendorCode

                                      select (facility == null) ? "No Facilities" : facility.FacilityName).ToList();

            objVendorDetail.Facility = Facilites;
            objVendorDetail.VendorImageSource = ImageSources;



            return View(objVendorDetail);
        }
    }
}
