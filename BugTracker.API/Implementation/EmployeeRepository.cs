using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Data;
using BugTracker.API.Interfaces;
using BugTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            this._context = context;

        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.Include(c => c.Comapny).ToListAsync();
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _context.Employees.Include(c => c.Comapny).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> GetEmployeeByUsername(string username)
        {
            return await _context.Employees.Include(c => c.Comapny).FirstOrDefaultAsync(e => e.Username.ToLower() == username);
        }

    }
}