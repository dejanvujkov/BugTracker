using AutoMapper;
using BugTracker.API.Models.Dto;

namespace BugTracker.API.Models.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}