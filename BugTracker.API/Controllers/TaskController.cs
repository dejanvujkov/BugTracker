using System.Threading.Tasks;
using BugTracker.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public TaskController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _dataContext.Tasks.ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var task = await _dataContext.Tasks.SingleOrDefaultAsync(task => task.Id == id);
            return Ok(task);
        }
    }
}