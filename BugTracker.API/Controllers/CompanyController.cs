using System.Threading.Tasks;
using BugTracker.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public CompanyController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _dataContext.Companies.ToListAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var companies = await _dataContext.Companies.SingleOrDefaultAsync(company => company.Id == id);
            return Ok(companies);
        }
    }
}