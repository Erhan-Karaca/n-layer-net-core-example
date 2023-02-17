using System.Linq.Expressions;
using AutoMapper;
using Firmabul.Core.DTOs;
using Firmabul.Core.Models;
using Firmabul.Core.Repositories;
using Firmabul.Core.Services;
using Firmabul.Core.UnitOfWorks;
using Firmabul.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Firmabul.Caching;

public class CompanyServiceWithCaching : ICompanyService
{
    private const string CacheCompanyKey = "companiesCache";
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;
    private readonly ICompanyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, ICompanyRepository repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _memoryCache = memoryCache;
        _repository = repository;
        _unitOfWork = unitOfWork;

        if (!_memoryCache.TryGetValue(CacheCompanyKey, out _))
        {
            _memoryCache.Set(CacheCompanyKey, _repository.GetCompaniesWithSector().Result);
        }
        
    }

    public Task<Company> GetByIdAsync(int id)
    {
        var company = _memoryCache.Get<List<Company>>(CacheCompanyKey)!.FirstOrDefault(x => x.Id == id);
        if (company==null)
        {
            throw new NotFoundException($"{typeof(Company).Name}({id}) not found");
        }
        return Task.FromResult(company);
    }

    public Task<IEnumerable<Company>> GetAllAsync()
    {
        return Task.FromResult(_memoryCache.Get<IEnumerable<Company>>(CacheCompanyKey))!;
    }

    public IQueryable<Company> Where(Expression<Func<Company, bool>> expression)
    {
        return _memoryCache.Get<List<Company>>(CacheCompanyKey)!.Where(expression.Compile()).AsQueryable();
    }

    public Task<bool> AnyAsync(Expression<Func<Company, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<Company> AddAsync(Company entity)
    {
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        await CacheAllCompaniesAsync();
        return entity;
    }

    public async Task<IEnumerable<Company>> AddRangeAsync(IEnumerable<Company> entities)
    {
        await _repository.AddRangeAsync(entities);
        await _unitOfWork.CommitAsync();
        await CacheAllCompaniesAsync();
        return entities;
    }

    public async Task UpdateAsync(Company entity)
    {
        _repository.Update(entity);
        await _unitOfWork.CommitAsync();
        await CacheAllCompaniesAsync();
    }

    public async Task RemoveAsync(Company entity)
    {
        _repository.Remove(entity);
        await _unitOfWork.CommitAsync();
        await CacheAllCompaniesAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<Company> entities)
    {
        _repository.RemoveRange(entities);
        await _unitOfWork.CommitAsync();
        await CacheAllCompaniesAsync();
    }

    public Task<CustomResponseDto<List<CompanyWithSectorDto>>> GetCompaniesWithSector()
    {
        var companies = _memoryCache.Get<IEnumerable<Company>>(CacheCompanyKey);
        var companiesWithSectorDto = _mapper.Map<List<CompanyWithSectorDto>>(companies);
        return Task.FromResult(CustomResponseDto<List<CompanyWithSectorDto>>.Success(200, companiesWithSectorDto));
    }

    public async Task CacheAllCompaniesAsync()
    {
        _memoryCache.Set(CacheCompanyKey, await _repository.GetAll().ToListAsync());
    }
    
}