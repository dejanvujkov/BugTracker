using System.Threading.Tasks;
using BugTracker.API.Data;
using BugTracker.API.Interfaces;

namespace BugTracker.API.Implementation
{
    public class BugTrackerRepository : IBugTrackerRepository
    {
        private readonly DataContext _context;
        public BugTrackerRepository(DataContext context)
        {
            this._context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}