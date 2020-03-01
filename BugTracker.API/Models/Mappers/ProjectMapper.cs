using BugTracker.API.Models.Dto;
using AutoMapper;

namespace BugTracker.API.Models.Mappers
{
    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            CreateMap<Project, ProjectDto>();
        }
    }
}