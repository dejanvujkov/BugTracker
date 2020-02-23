using System.Threading.Tasks;
using BugTracker.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProjectController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _dataContext.Projects.ToListAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var project = await _dataContext.Projects.SingleOrDefaultAsync(project => project.Id == id);
            return Ok(project);
        }
    }
}