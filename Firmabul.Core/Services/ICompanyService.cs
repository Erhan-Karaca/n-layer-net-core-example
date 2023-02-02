using Firmabul.Core.DTOs;
using Firmabul.Core.Models;

namespace Firmabul.Core.Services;

public interface ICompanyService : IService<Company>
{
    Task<CustomResponseDto<List<CompanyWithSectorDto>>> GetCompaniesWithSector();
}