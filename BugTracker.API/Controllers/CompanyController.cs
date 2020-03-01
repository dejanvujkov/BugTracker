using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.API.Interfaces;
using BugTracker.API.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyRepository.GetAllComapnies();
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companiesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }
    }
}