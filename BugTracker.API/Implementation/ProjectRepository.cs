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
        private readonly IEmployeeRepository _employeeRepository;
        public ProjectRepository(DataContext context, IEmployeeRepository employeeRepository)
        {
            this._context = context;
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.Include(c => c.Company).ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsForCompany(int companyId)
        {
            return await _context.Projects.Where(p => p.CompanyId == companyId).Include(c => c.Company).ToListAsync();
        }
        
        public async Task<IEnumerable<Project>> GetProjectsForUsersCompany(string username)
        {
            var usersCompanyId = _employeeRepository.GetEmployeeByUsername(username).Result.CompanyId;
            return await _context.Projects.Where(p => p.CompanyId == usersCompanyId).Include(c => c.Company).ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _context.Projects.Include(c => c.Company).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return await GetSingle(project.Id);
        }

        public async System.Threading.Tasks.Task DeleteProject(int projectId)
        {
            var projectToRemove = await _context.Projects.FindAsync(projectId);
            _context.Projects.Remove(projectToRemove);
            await _context.SaveChangesAsync();
        }
    }
}