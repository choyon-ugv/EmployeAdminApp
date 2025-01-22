using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminApp.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}
