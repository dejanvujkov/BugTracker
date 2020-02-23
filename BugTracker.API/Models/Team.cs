namespace BugTracker.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
    }
}