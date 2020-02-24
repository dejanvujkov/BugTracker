using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.Models.Dto
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "You must specify password between 8-50 characters.")]
        public string Password { get; set; }
    }
}