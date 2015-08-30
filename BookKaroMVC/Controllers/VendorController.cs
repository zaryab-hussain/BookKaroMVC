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

       
    }
}
