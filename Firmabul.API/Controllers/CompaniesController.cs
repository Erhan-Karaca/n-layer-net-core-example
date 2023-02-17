using AutoMapper;
using Firmabul.API.Filters;
using Firmabul.Core.DTOs;
using Firmabul.Core.Models;
using Firmabul.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Firmabul.API.Controllers;

public class CompaniesController : CustomBaseController
{
    private readonly IMapper _mapper;
    private readonly ICompanyService _service;

    public CompaniesController(IMapper mapper, ICompanyService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    /// <summary>
    ///  GET api/companies/GetCompaniesWithSector
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<IActionResult> GetCompaniesWithSector()
    {
        return CreateActionResult(await _service.GetCompaniesWithSector());
    }

    /// <summary>
    ///  GET api/companies
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var companies = await _service.GetAllAsync();
        var companiesDto = _mapper.Map<List<CompanyDto>>(companies.ToList());
        return CreateActionResult(CustomResponseDto<List<CompanyDto>>.Success(200, companiesDto));
    }

    /// <summary>
    ///  GET api/companies/5
    /// </summary>
    /// <returns></returns>
    [ServiceFilter(typeof(NotFoundFilter<Company>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var company = await _service.GetByIdAsync(id);
        var companyDto = _mapper.Map<CompanyDto>(company);
        return CreateActionResult(CustomResponseDto<CompanyDto>.Success(200, companyDto));
    }

    /// <summary>
    ///  POST api/companies
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Save(CompanyDto companyDto)
    {
        var company = await _service.AddAsync(_mapper.Map<Company>(companyDto));
        var companyResponseDto = _mapper.Map<CompanyDto>(company);
        return CreateActionResult(CustomResponseDto<CompanyDto>.Success(201, companyResponseDto));
    }

    /// <summary>
    ///  PUT api/companies
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update(CompanyUpdateDto companyDto)
    {
        await _service.UpdateAsync(_mapper.Map<Company>(companyDto));
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
    
    /// <summary>
    ///  DELETE api/companies/5
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var company = await _service.GetByIdAsync(id);
        await _service.RemoveAsync(company);
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}