using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;
using System.Data.Entity;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private ManagementDbContext db = new ManagementDbContext();
        public ActionResult Index()
        {
            return View();
        }
        //Add a button to the page and on click of that button, Columns should be displayed with the help of LINQ query. Columns are Employee Id, First Name, Middle Name, Last Name, Designation Name, DOB, Mobile Number, Address & Salary
        public ActionResult Query1()
        {
            var data = db.Employees
                         .Include(e => e.Designation)
                         .Select(e => new Query1
                         {
                             Id = e.Id,
                             FirstName = e.FirstName,
                             MiddleName = e.MiddleName,
                             LastName = e.LastName,
                             DesignationName = e.Designation.Name,
                             DOB = e.DOB,
                             MobileNumber = e.MobileNumber,
                             Address = e.Address,
                             Salary = e.Salary
                         }).ToList();

            return View(data);
        }

        //Add a button to the page and on click of that button, display the count number of records of the employee by designation name using LINQ query.
        public ActionResult Query2()
        {
            var data = db.Employees
                         .GroupBy(e => e.Designation.Name)
                         .Select(g => new Query2
                         {
                             DesignationName = g.Key,
                             EmployeeCount = g.Count()
                         }).ToList();
            return View(data);
        }
    }
}