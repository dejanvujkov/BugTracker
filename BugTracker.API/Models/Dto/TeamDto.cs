namespace BugTracker.API.Models.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
    }
}