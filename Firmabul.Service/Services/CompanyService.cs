using AutoMapper;
using Firmabul.Core.DTOs;
using Firmabul.Core.Models;
using Firmabul.Core.Repositories;
using Firmabul.Core.Services;
using Firmabul.Core.UnitOfWorks;

namespace Firmabul.Service.Services;

public class CompanyService : Service<Company>, ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    
    public CompanyService(IGenericRepository<Company> repository, IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<List<CompanyWithSectorDto>>> GetCompaniesWithSector()
    {
        var companies = await _companyRepository.GetCompaniesWithSector();
        var companiesDto = _mapper.Map<List<CompanyWithSectorDto>>(companies);
        return CustomResponseDto<List<CompanyWithSectorDto>>.Success(200, companiesDto);
    }
}