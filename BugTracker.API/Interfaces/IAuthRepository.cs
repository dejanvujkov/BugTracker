using System.Threading.Tasks;
using BugTracker.API.Models;

namespace BugTracker.API.Interfaces
{
    public interface IAuthRepository
    {
        Task<Employee> Register(Employee employee, string password);
        Task<Employee> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}