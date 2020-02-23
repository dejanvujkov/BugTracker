using System.Threading.Tasks;
using BugTracker.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public TeamController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _dataContext.Teams.ToListAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var team = await _dataContext.Teams.SingleOrDefaultAsync(team => team.Id == id);
            return Ok(team);
        }
    }
}