using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.API.Data;
using BugTracker.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext context)
        {
            this._context = context;

        }
        public async Task<IEnumerable<Models.Task>> GetAll()
        {
            return await _context.Tasks.Include(p => p.Project).Include(e => e.Worker).ToListAsync();
        }

        public async Task<Models.Task> GetSingle(int id)
        {
            return await _context.Tasks.Include(p => p.Project).Include(e => e.Worker).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Models.Task>> GetTasksForCompany(int companyId)
        {
            return await _context.Tasks.Include(p => p.Project).Include(w => w.Worker).Where(p => p.Project.CompanyId == companyId).ToListAsync();
        }
    }
}