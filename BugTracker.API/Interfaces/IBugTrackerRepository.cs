using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.API.Interfaces
{
    public interface IBugTrackerRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

    }
}