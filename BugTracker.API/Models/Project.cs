using System;
namespace BugTracker.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime DueDate { get; set; }

    }
}