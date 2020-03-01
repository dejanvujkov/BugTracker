using System;

namespace BugTracker.API.Models.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}