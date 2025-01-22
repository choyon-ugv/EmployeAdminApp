using EmployeeAdminApp.Data;
using EmployeeAdminApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        private bool IsAdminAuthenticated()
        {
            return HttpContext.Session.GetString("AdminUsername") != null;
        }

        public IActionResult Index()
        {
            if (!IsAdminAuthenticated())
                return RedirectToAction("Login", "Admin");

            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            if (!IsAdminAuthenticated())
                return RedirectToAction("Login", "Admin");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (!IsAdminAuthenticated())
                return RedirectToAction("Login", "Admin");

            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Edit/{id}
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);

                if (existingEmployee == null)
                {
                    return NotFound();
                }

                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Position = employee.Position;
                existingEmployee.Salary = employee.Salary;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);  // Return the same view if validation fails
        }


        public IActionResult Delete(int id)
        {
            if (!IsAdminAuthenticated())
                return RedirectToAction("Login", "Admin");

            var employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
