using Firmabul.Core.Models;

namespace Firmabul.Core.Repositories;

public interface ISectorRepository : IGenericRepository<Sector>
{
    Task<Sector> GetSingleSectorByIdWithCompaniesAsync(int sectorId);
}