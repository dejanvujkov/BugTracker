using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Models;

namespace BugTracker.API.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetSingle(int id);
        Task<IEnumerable<Project>> GetAll();
        Task<IEnumerable<Project>> GetProjectsForCompany(int companyId);
        Task<IEnumerable<Project>> GetProjectsForUsersCompany(string username);
        Task<Project> UpdateProject(Project project);
        System.Threading.Tasks.Task DeleteProject(int projectId);
    }
}