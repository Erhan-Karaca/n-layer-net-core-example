using Firmabul.Core.Models;
using Firmabul.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Firmabul.Repository.Repositories;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<List<Company>> GetCompaniesWithSector()
    {
        return await _context.Companies.Include(x => x.Sector).ToListAsync();
    }
}