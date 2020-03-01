using AutoMapper;
using BugTracker.API.Models.Dto;

namespace BugTracker.API.Models.Mappers
{
    public class TeamMapper : Profile
    {
        public TeamMapper()
        {
            CreateMap<Team, TeamDto>();
        }
    }
}