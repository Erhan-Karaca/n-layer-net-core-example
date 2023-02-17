namespace Firmabul.Core.DTOs;

public class SectorWithCompaniesDto : SectorDto
{
    public List<CompanyDto> Companies { get; set; }
}