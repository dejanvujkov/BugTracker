using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.API.Data;
using BugTracker.API.Interfaces;
using BugTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            this._context = context;

        }
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.Include(c => c.Company).ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsForCompany(int companyId)
        {
            return await _context.Projects.Where(p => p.CompanyId == companyId).Include(c => c.Company).ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _context.Projects.Include(c => c.Company).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}