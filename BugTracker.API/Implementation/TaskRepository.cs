using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.API.Data;
using BugTracker.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TaskRepository(DataContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<Models.Task>> GetAll()
        {
            return await _context.Tasks.Include(p => p.Project).Include(e => e.Worker).ToListAsync();
        }

        public async Task<Models.Task> GetSingle(int id)
        {
            return await _context.Tasks.Include(p => p.Project).Include(e => e.Worker).Include(c => c.Project.Company).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Models.Task>> GetTasksForCompany(int companyId)
        {
            return await _context.Tasks.Include(p => p.Project).Include(w => w.Worker).Where(p => p.Project.CompanyId == companyId).ToListAsync();
        }

        public async Task<IEnumerable<Models.Task>> GetTasksForProject(int projectId)
        {
            return await _context.Tasks.Include(p => p.Project).Include(c => c.Project.Company).Include(w => w.Worker).Where(predicate => predicate.ProjectId == projectId).ToListAsync();
        }

        public async Task<int> Update(Models.Task task)
        {
            var taskFromRepo = GetSingle(task.Id).Result;
            taskFromRepo.Status = task.Status;
            taskFromRepo.Description = task.Description;
            taskFromRepo.DueDate = task.DueDate;
            taskFromRepo.GiverId = task.GiverId;
            taskFromRepo.PercentageDone = task.PercentageDone;
            taskFromRepo.StartDate = task.StartDate;
            taskFromRepo.Title = task.Title;
            taskFromRepo.WorkerId = task.WorkerId;
            int result = await _context.SaveChangesAsync();
            return result;
        }
    }
}