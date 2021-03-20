using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTracker.API.Interfaces;
using AutoMapper;
using BugTracker.API.Models.Dto;
using BugTracker.API.Models;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _repository.GetAll();
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            return Ok(projectDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var project = await _repository.GetSingle(id);
            var projectDto = _mapper.Map<ProjectDto>(project);
            return Ok(projectDto);
        }

        [HttpGet("getProjectsForUser")]
        public async Task<IActionResult> GetProjectsForCompany()
        {
            var project = await _repository.GetProjectsForUsersCompany(User.Identity.Name);
            var projectDto = _mapper.Map<IEnumerable<ProjectDto>>(project);
            return Ok(projectDto);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            var updatedProject = await _repository.UpdateProject(project);
            var updatedProjectDto = _mapper.Map<ProjectDto>(updatedProject);
            return Ok(updatedProjectDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            await _repository.DeleteProject(projectId);
            return Ok();
        }
    }
}