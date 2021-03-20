using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Models;

namespace BugTracker.API.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByUsername(string username);
        Task<Employee> GetSingle(int id);
        Task<IEnumerable<Employee>> GetAll();
    }
}