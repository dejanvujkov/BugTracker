using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Email { get; set; }
        public Company Comapny { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public int? TeamId { get; set; }
        public EmployeeType EmployeeType { get; set; }

    }
}