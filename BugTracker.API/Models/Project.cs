using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public string Description { get; set; }

    }
}