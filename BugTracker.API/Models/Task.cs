using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public Employee Worker { get; set; }
        [Required]
        public int WorkerId { get; set; }
        public int GiverId { get; set; }
        [Required]
        public int PercentageDone { get; set; }
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public TaskStatus Status { get; set; }

    }
}