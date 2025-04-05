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
    public class EmployeeController : Controller
    {
        private ManagementDbContext db = new ManagementDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Designation);
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeT2 employeeT2 = db.Employees.Find(id);
            if (employeeT2 == null)
            {
                return HttpNotFound();
            }
            return View(employeeT2);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,DOB,MobileNumber,Address,Salary,DesignationId")] EmployeeT2 employeeT2)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employeeT2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employeeT2.DesignationId);
            return View(employeeT2);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeT2 employeeT2 = db.Employees.Find(id);
            if (employeeT2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employeeT2.DesignationId);
            return View(employeeT2);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,DOB,MobileNumber,Address,Salary,DesignationId")] EmployeeT2 employeeT2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeT2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employeeT2.DesignationId);
            return View(employeeT2);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeT2 employeeT2 = db.Employees.Find(id);
            if (employeeT2 == null)
            {
                return HttpNotFound();
            }
            return View(employeeT2);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeT2 employeeT2 = db.Employees.Find(id);
            db.Employees.Remove(employeeT2);
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
