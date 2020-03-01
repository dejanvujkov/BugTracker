using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Data;
using BugTracker.API.Interfaces;
using BugTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Implementation
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;
        public TeamRepository(DataContext context)
        {
            this._context = context;

        }
        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _context.Teams.Include(p => p.Project).Include(c => c.Company).ToListAsync();
        }

        public async Task<Team> GetSingle(int id)
        {
            return await _context.Teams.Include(p => p.Project).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}