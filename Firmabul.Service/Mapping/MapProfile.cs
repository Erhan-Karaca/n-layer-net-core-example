using AutoMapper;
using Firmabul.Core.DTOs;
using Firmabul.Core.Models;

namespace Firmabul.Service.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Sector, SectorDto>().ReverseMap();
        CreateMap<CompanyUpdateDto, Company>();
        CreateMap<Company, CompanyWithSectorDto>();
    }
}