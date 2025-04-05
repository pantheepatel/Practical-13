using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class DesignationController : Controller
    {
        private ManagementDbContext db = new ManagementDbContext();

        // GET: Designation
        public ActionResult Index()
        {
            return View(db.Designations.ToList());
        }

        // GET: Designation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationT2 designationT2 = db.Designations.Find(id);
            if (designationT2 == null)
            {
                return HttpNotFound();
            }
            return View(designationT2);
        }

        // GET: Designation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DesignationT2 designationT2)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designationT2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designationT2);
        }

        // GET: Designation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationT2 designationT2 = db.Designations.Find(id);
            if (designationT2 == null)
            {
                return HttpNotFound();
            }
            return View(designationT2);
        }

        // POST: Designation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DesignationT2 designationT2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designationT2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designationT2);
        }

        // GET: Designation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationT2 designationT2 = db.Designations.Find(id);
            if (designationT2 == null)
            {
                return HttpNotFound();
            }
            return View(designationT2);
        }

        // POST: Designation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesignationT2 designationT2 = db.Designations.Find(id);

            // Check for foreign key reference
            bool isInUse = db.Employees.Any(e => e.DesignationId == id);
            if (isInUse)
            {
                TempData["ErrorMessage"] = "This designation is assigned to one or more employees. Please reassign or remove those employees before deleting.";
                return RedirectToAction("Delete", new { id = id });
            }

            db.Designations.Remove(designationT2);
            db.SaveChanges();
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
