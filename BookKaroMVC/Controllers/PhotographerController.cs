using BookKaroMVC.Models;
using BookKaroMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookKaroMVC.Controllers
{
    public class PhotographerController : Controller
    {
        private BookKaroEntities2 db = new BookKaroEntities2();
        // GET: Photographer
        public ActionResult Index(int? Areas, int? Events)
        {
            //var vendor = db.tblServices.Where(r => r.ServiceID == 1)
            //                   .SelectMany(r => r.tblVendors)
            //                   .Intersect
            //                   (
            //                     db.tblVendors.Where(l => l.description == "Amsterdam")
            //                     .SelectMany(l => l.Person)
            //                    ).ToList();

            var vendor = db.tblVendors.Where(s => s.tblServices.Any(c => c.ServiceID == 1)).Select(x => new SearchResultsViewModel
            {
                AreaName = x.VendorAddress,
                ImageSource = x.VendorImageSource,
                VendorName = x.VendorName,
                PriceRangeMinimum = x.VendorPriceRangeMinimum,
                VendorID = x.VendorID
               
            });
               


         
            return View(vendor);
        }

        // GET: Photographer/Details/5
        [HttpGet]
        public ActionResult Detail(int id)
        {
            //var SearchCriteria = new HomeViewModel();
            //SearchCriteria.LocationID = ;

            int VendorCode = Convert.ToInt32(id);

            var objVendorDetail = new VendorDetailViewModel();

            objVendorDetail = (from vendor in db.tblVendors

                               //from vendorCategory in vendor.tblCategories
                               //join category in db.tblCategories on vendorCategory.CategoryID equals category.CategoryID
                               join a in db.tblAreas on vendor.AreaCode equals a.AreaCode

                               //join i in db.tblImages on v.VendorID equals i.VendorID
                               where vendor.VendorID == VendorCode
                               select new VendorDetailViewModel()
                               {
                                 
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
                                      join facility in db.tblFacilities on vendorFacility.FacilityID equals facility.FacilityID into ps
                                      from facility in ps.DefaultIfEmpty()
                                      where vendor.VendorID == VendorCode

                                      select (facility == null) ? "No Facilities" : facility.FacilityName).ToList();

            objVendorDetail.Facility = Facilites;
            objVendorDetail.VendorImageSource = ImageSources;



            return View(objVendorDetail);
        }

        // GET: Photographer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photographer/Create
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

        // GET: Photographer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Photographer/Edit/5
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

        // GET: Photographer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Photographer/Delete/5
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
    }
}
