using AutoMapper;
using Firmabul.Core.DTOs;
using Firmabul.Core.Models;
using Firmabul.Core.Repositories;
using Firmabul.Core.Services;
using Firmabul.Core.UnitOfWorks;

namespace Firmabul.Service.Services;

public class SectorService : Service<Sector>, ISectorService
{
    private readonly ISectorRepository _sectorRepository;
    private readonly IMapper _mapper;
    
    public SectorService(IGenericRepository<Sector> repository, IUnitOfWork unitOfWork, ISectorRepository sectorRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _sectorRepository = sectorRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<SectorWithCompaniesDto>> GetSingleSectorByIdWithCompaniesAsync(int sectorId)
    {
        var sector = await _sectorRepository.GetSingleSectorByIdWithCompaniesAsync(sectorId);
        var sectorDto = _mapper.Map<SectorWithCompaniesDto>(sector);
        return CustomResponseDto<SectorWithCompaniesDto>.Success(200, sectorDto);
    }
}