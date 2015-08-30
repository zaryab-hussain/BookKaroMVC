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
    public class FacilityController : Controller
    {
        private BookKaroEntities1 db = new BookKaroEntities1();

        // GET: /Facility/
        public async Task<ActionResult> Index()
        {
            return View(await db.tblFacilities.ToListAsync());
        }

        // GET: /Facility/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFacility tblfacility = await db.tblFacilities.FindAsync(id);
            if (tblfacility == null)
            {
                return HttpNotFound();
            }
            return View(tblfacility);
        }

        // GET: /Facility/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Facility/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(tblFacility tblfacility)
        {
            if (ModelState.IsValid)
            {
                db.tblFacilities.Add(tblfacility);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblfacility);
        }

        // GET: /Facility/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFacility tblfacility = await db.tblFacilities.FindAsync(id);
            if (tblfacility == null)
            {
                return HttpNotFound();
            }
            return View(tblfacility);
        }

        // POST: /Facility/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="FacilityID,FacilityName,FacilityDescription,FacilityRemarks")] tblFacility tblfacility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblfacility).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblfacility);
        }

        // GET: /Facility/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFacility tblfacility = await db.tblFacilities.FindAsync(id);
            if (tblfacility == null)
            {
                return HttpNotFound();
            }
            return View(tblfacility);
        }

        // POST: /Facility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblFacility tblfacility = await db.tblFacilities.FindAsync(id);
            db.tblFacilities.Remove(tblfacility);
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
