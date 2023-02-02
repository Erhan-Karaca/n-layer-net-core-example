using Firmabul.Core.Models;

namespace Firmabul.Core.Repositories;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<List<Company>> GetCompaniesWithSector();
}