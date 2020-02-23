
using BugTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}