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
    public class UserController : Controller
    {
        private BookKaroEntities2 db = new BookKaroEntities2();

        // GET: /User/
        public async Task<ActionResult> Index()
        {
            var tblusers = db.tblUsers.Include(t => t.tblRole);
            return View(await tblusers.ToListAsync());
        }

        // GET: /User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tbluser = await db.tblUsers.FindAsync(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            return View(tbluser);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.tblRoles, "RoleID", "RoleName");
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="UserID,UserName,UserFirstName,UserLastName,UserDisplayName,UsePassword,UseLast_Login,UserRegistration,UserType,UserPreviousPasswordDate,UserLoginDate,UserAddress,RoleID")] tblUser tbluser)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tbluser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.tblRoles, "RoleID", "RoleName", tbluser.RoleID);
            return View(tbluser);
        }

        // GET: /User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tbluser = await db.tblUsers.FindAsync(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.tblRoles, "RoleID", "RoleName", tbluser.RoleID);
            return View(tbluser);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="UserID,UserName,UserFirstName,UserLastName,UserDisplayName,UsePassword,UseLast_Login,UserRegistration,UserType,UserPreviousPasswordDate,UserLoginDate,UserAddress,RoleID")] tblUser tbluser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbluser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.tblRoles, "RoleID", "RoleName", tbluser.RoleID);
            return View(tbluser);
        }

        // GET: /User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tbluser = await db.tblUsers.FindAsync(id);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            return View(tbluser);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblUser tbluser = await db.tblUsers.FindAsync(id);
            db.tblUsers.Remove(tbluser);
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
