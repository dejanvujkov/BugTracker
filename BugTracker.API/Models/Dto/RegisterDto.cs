using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.Models.Dto
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Email not long enough.")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "You must specify password between 8-50 characters.")]
        public string Password { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public int? TeamId { get; set; }
        public EmployeeType employeeType { get; set; }
    }
}