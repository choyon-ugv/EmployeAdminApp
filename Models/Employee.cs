using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [StringLength(100, ErrorMessage = "Position cannot exceed 100 characters.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; }
    }
}
