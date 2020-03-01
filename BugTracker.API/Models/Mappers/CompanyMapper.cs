using AutoMapper;
using BugTracker.API.Models.Dto;

namespace BugTracker.API.Models.Mappers
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<Company, CompanyDto>();
        }
    }
}