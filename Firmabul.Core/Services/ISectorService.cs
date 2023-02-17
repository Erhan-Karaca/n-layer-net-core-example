using Firmabul.Core.DTOs;
using Firmabul.Core.Models;

namespace Firmabul.Core.Services;

public interface ISectorService : IService<Sector>
{
    public Task<CustomResponseDto<SectorWithCompaniesDto>> GetSingleSectorByIdWithCompaniesAsync(int sectorId);
}