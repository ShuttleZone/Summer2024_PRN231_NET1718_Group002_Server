using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.DependencyInjection.Services.Package;
using ShuttleZone.Domain.WebRequests.Packages;

namespace ShuttleZone.Api.Controllers;

public class PackageController: BaseApiController
{
    private readonly IPackageService _packageService;

    public PackageController(IPackageService packageService)
    {
        _packageService = packageService;
    }

    [HttpPost("/api/Package/create-package")]
    public async Task<IActionResult> CreatePackage([FromBody]CreatePackageDto createPackageDto)
    {
        if (createPackageDto == null)
            return BadRequest("Package data is not correct !");
        return Ok(await _packageService.CreatePackage(createPackageDto));
    }

}