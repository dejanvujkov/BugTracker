using AutoMapper;
using BugTracker.API.Models.Dto;

namespace BugTracker.API.Models.Mappers
{
    public class TaskMapper : Profile
    {
        public TaskMapper()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<TaskDto, Task>();

            CreateMap<TaskDto, Models.Task>();
            CreateMap<Models.Task, TaskDto>();
        }
    }
}