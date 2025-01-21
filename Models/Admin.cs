using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminApp.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
