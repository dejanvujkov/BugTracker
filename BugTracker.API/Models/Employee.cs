namespace BugTracker.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public int TeamId { get; set; }
        public EmployeeType EmployeeType { get; set; }

    }
}