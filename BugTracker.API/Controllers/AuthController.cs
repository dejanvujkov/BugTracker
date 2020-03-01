using System;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using BugTracker.API.Interfaces;
using BugTracker.API.Models;
using BugTracker.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthRepository repository, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            registerDto.Username = registerDto.Username.ToLower();
            if (await _repository.UserExists(registerDto.Username))
            {
                return BadRequest("Username already taken");
            }
            var employeeToCreate = new Employee()
            {
                Username = registerDto.Username,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                TeamId = registerDto.TeamId,
                CompanyId = registerDto.CompanyId,
                EmployeeType = registerDto.employeeType
            };
            var createdUser = await _repository.Register(employeeToCreate, registerDto.Password);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var employee = await _repository.Login(loginDto.Username.ToLower(), loginDto.Password);

            if (employee == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Name, employee.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}