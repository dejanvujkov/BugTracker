using System.Linq;
using System.Threading.Tasks;
using BugTracker.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EmployeeController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _dataContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var employee = await _dataContext.Employees.SingleOrDefaultAsync(employee => employee.Id == id);
            return Ok(employee);
        }

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetEmployeesFromType(EmployeeType type)
        {
            var employee = await _dataContext.Employees.Where(employee => employee.EmployeeType == type).ToListAsync();
            return Ok(employee);
        }
    }
}