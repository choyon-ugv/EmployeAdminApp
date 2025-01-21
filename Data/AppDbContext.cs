using Microsoft.EntityFrameworkCore;
using EmployeeAdminApp.Models;
using System.Collections.Generic;

namespace EmployeeAdminApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
