using Firmabul.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Firmabul.API.Controllers;

public class SectorsController : CustomBaseController
{
    private readonly ISectorService _sectorService;

    public SectorsController(ISectorService sectorService)
    {
        _sectorService = sectorService;
    }

    // api/sectors/GetSingleSectorByIdWithCompanies/2
    [HttpGet("[action]/{sectorId}")]
    public async Task<IActionResult> GetSingleSectorByIdWithCompanies(int sectorId)
    {
        return CreateActionResult(await _sectorService.GetSingleSectorByIdWithCompaniesAsync(sectorId));
    }
}