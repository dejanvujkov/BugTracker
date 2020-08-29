using System;
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
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _repository.GetAll();
            var tasksDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return Ok(tasksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var task = await _repository.GetSingle(id);
            var taskDto = _mapper.Map<TaskDto>(task);
            return Ok(taskDto);
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetTasksForCompany(int companyId)
        {
            var tasks = await _repository.GetTasksForCompany(companyId);
            var tasksDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return Ok(tasksDto);
        }

        [HttpGet("projectId/{projectId}")]
        public async Task<IActionResult> GetTasksForProject(int projectId)
        {
            var tasks = await _repository.GetTasksForProject(projectId);
            var tasksDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return Ok(tasksDto);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateTask([FromBody] Models.Task task)
        {
            if (await _repository.Update(task) > 0)
            {
                return Ok(task);
            }
            return NoContent();

        }
    }
}