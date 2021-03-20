using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Interfaces
{
    public interface ITaskRepository
    {
        Task<Models.Task> GetSingle(int id);
        Task<IEnumerable<Models.Task>> GetAll(string username);
        Task<IEnumerable<Models.Task>> GetTasksForCompany(int companyId);
        Task<IEnumerable<Models.Task>> GetTasksForProject(int projectId);
        Task<int> Update(Models.Task task);
    }
}