using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Models;

namespace BugTracker.API.Interfaces
{
    public interface ITaskRepository
    {
        Task<Models.Task> GetSingle(int id);
        Task<IEnumerable<Models.Task>> GetAll();
    }
}