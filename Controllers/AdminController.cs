using EmployeeAdminApp.Data;
using EmployeeAdminApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var existingAdmin = _context.Admins
                .FirstOrDefault(a => a.Username == admin.Username &&
                                 a.Password == admin.Password &&
                                 a.Email == admin.Email);

            if (existingAdmin != null)
            {
                // Set session value
                HttpContext.Session.SetString("AdminUsername", existingAdmin.Username);
                // Redirect to Employee Index
                return RedirectToAction("Index", "Employee");
            }

            // Show error message if login fails
            ModelState.AddModelError("", "Invalid credentials. Please try again.");
            return View(admin);
        }

        public IActionResult Logout()
        {
            // Clear session on logout
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
