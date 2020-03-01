using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BugTracker.API.Interfaces;
using AutoMapper;
using BugTracker.API.Models.Dto;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;

        public TeamController(ITeamRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _repository.GetAll();
            var teamsDto = _mapper.Map<IEnumerable<TeamDto>>(teams);
            return Ok(teamsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var team = await _repository.GetSingle(id);
            var teamDto = _mapper.Map<TeamDto>(team);
            return Ok(teamDto);
        }
    }
}