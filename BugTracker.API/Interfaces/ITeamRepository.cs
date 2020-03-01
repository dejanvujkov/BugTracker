using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Models;

namespace BugTracker.API.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> GetSingle(int id);
        Task<IEnumerable<Team>> GetAll();
    }
}