using System.Linq;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext _context = new EmployeeDbContext();

        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //edit
        public ActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return HttpNotFound();
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //delete
        public ActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return HttpNotFound();
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //view
        public ActionResult Details(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return HttpNotFound();
            return View(emp);
        }
    }
}
