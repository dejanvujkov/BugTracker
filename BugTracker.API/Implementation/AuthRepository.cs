using System;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.API.Data;
using BugTracker.API.Interfaces;
using BugTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.API.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context = context;

        }
        public async Task<Employee> Login(string username, string password)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Username == username);

            if (employee == null) return null;
            if (!VerifyPasswordHash(password, employee.PasswordHash, employee.PasswordSalt)) return null;

            return employee;

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] == passwordHash[i])
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public async Task<Employee> Register(Employee employee, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            employee.PasswordHash = passwordHash;
            employee.PasswordSalt = passwordSalt;

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Employees.AnyAsync(x => x.Username == username)) return true;
            return false;
        }
    }
}