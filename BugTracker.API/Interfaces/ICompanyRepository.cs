using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.API.Models;

namespace BugTracker.API.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(int id);
        Task<IEnumerable<Company>> GetAllComapnies();
    }
}