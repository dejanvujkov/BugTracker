using System;

namespace BugTracker.API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int WorkerId { get; set; }
        public int GiverId { get; set; }
        public int PercentageDone { get; set; }
        public string Description { get; set; }

    }
}