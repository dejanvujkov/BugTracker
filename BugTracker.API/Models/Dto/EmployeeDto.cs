namespace BugTracker.API.Models.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public Company Comapny { get; set; }
        public int CompanyId { get; set; }
        public int? TeamId { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}