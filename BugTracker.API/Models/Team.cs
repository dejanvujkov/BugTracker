using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Project Project { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public string Name { get; set; }
    }
}