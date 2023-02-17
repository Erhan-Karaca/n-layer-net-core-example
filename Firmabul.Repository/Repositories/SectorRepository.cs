using Firmabul.Core.Models;
using Firmabul.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Firmabul.Repository.Repositories;

public class SectorRepository : GenericRepository<Sector>, ISectorRepository
{
    public SectorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Sector> GetSingleSectorByIdWithCompaniesAsync(int sectorId)
    {
        return await _context.Sectors.Include(x=>x.Companies).Where(x=>x.Id==sectorId).SingleOrDefaultAsync();
    }
}