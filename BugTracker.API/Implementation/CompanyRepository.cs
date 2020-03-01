using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Data;
using BugTracker.API.Interfaces;
using BugTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context)
        {
            this._context = context;

        }
        public async Task<IEnumerable<Company>> GetAllComapnies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}