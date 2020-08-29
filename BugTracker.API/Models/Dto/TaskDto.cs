using System;

namespace BugTracker.API.Models.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public Employee Worker { get; set; }
        public int WorkerId { get; set; }
        public int GiverId { get; set; }
        public int PercentageDone { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
    }
}