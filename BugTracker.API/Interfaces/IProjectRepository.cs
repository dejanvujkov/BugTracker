using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Models;

namespace BugTracker.API.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetSingle(int id);
        Task<IEnumerable<Project>> GetAll();
    }
}