using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookKaroMVC.Models;

namespace BookKaroMVC.Controllers
{
    public class VendorController : Controller
    {
        private BookKaroEntities2 db = new BookKaroEntities2();

        // GET: /Vendor/
        public async Task<ActionResult> Index()
        {
            var tblvendors = db.tblVendors.Include(t => t.tblArea).Include(t => t.tblMembership).Include(t => t.tblUser);
            return View(await tblvendors.ToListAsync());
        }

        // GET: /Vendor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVendor tblvendor = await db.tblVendors.FindAsync(id);
            if (tblvendor == null)
            {
                return HttpNotFound();
            }
            return View(tblvendor);
        }

        // GET: /Vendor/Create
        public ActionResult Create()
        {
            ViewBag.AreaCode = new SelectList(db.tblAreas, "AreaCode", "AreaDescription");
            ViewBag.MembershipID = new SelectList(db.tblMemberships, "MembershipID", "MembershipCategory");
            ViewBag.UserID = new SelectList(db.tblUsers, "UserID", "UserName");
            return View();
        }

        // POST: /Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="VendorID,VendorName,VendorPriceRangeMinimum,VendorCapacityMinimum,VendorEnteredOn,VendorEnteredBy,VendorUpdatedOn,VendorUpdatedBy,VendorPriceRangeMaximum,MembershipID,VendorAddress,VendorCapacityMaximum,UserID,AreaCode,VendorImageSource,VendorDescription")] tblVendor tblvendor)
        {
            if (ModelState.IsValid)
            {
                db.tblVendors.Add(tblvendor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AreaCode = new SelectList(db.tblAreas, "AreaCode", "AreaDescription", tblvendor.AreaCode);
            ViewBag.MembershipID = new SelectList(db.tblMemberships, "MembershipID", "MembershipCategory", tblvendor.MembershipID);
            ViewBag.UserID = new SelectList(db.tblUsers, "UserID", "UserName", tblvendor.UserID);
            return View(tblvendor);
        }

        // GET: /Vendor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVendor tblvendor = await db.tblVendors.FindAsync(id);
            if (tblvendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaCode = new SelectList(db.tblAreas, "AreaCode", "AreaDescription", tblvendor.AreaCode);
            ViewBag.MembershipID = new SelectList(db.tblMemberships, "MembershipID", "MembershipCategory", tblvendor.MembershipID);
            ViewBag.UserID = new SelectList(db.tblUsers, "UserID", "UserName", tblvendor.UserID);
            return View(tblvendor);
        }

        // POST: /Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="VendorID,VendorName,VendorPriceRangeMinimum,VendorCapacityMinimum,VendorEnteredOn,VendorEnteredBy,VendorUpdatedOn,VendorUpdatedBy,VendorPriceRangeMaximum,MembershipID,VendorAddress,VendorCapacityMaximum,UserID,AreaCode,VendorImageSource,VendorDescription")] tblVendor tblvendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblvendor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AreaCode = new SelectList(db.tblAreas, "AreaCode", "AreaDescription", tblvendor.AreaCode);
            ViewBag.MembershipID = new SelectList(db.tblMemberships, "MembershipID", "MembershipCategory", tblvendor.MembershipID);
            ViewBag.UserID = new SelectList(db.tblUsers, "UserID", "UserName", tblvendor.UserID);
            return View(tblvendor);
        }

        // GET: /Vendor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVendor tblvendor = await db.tblVendors.FindAsync(id);
            if (tblvendor == null)
            {
                return HttpNotFound();
            }
            return View(tblvendor);
        }

        // POST: /Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblVendor tblvendor = await db.tblVendors.FindAsync(id);
            db.tblVendors.Remove(tblvendor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
