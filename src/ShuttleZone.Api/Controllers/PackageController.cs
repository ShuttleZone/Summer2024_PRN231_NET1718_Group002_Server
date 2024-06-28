using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.DependencyInjection.Services.Package;
using ShuttleZone.Domain.WebRequests.Packages;
using ShuttleZone.Domain.WebResponses.Package;

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

    [EnableQuery]
    public  ActionResult<PackageResponseDto> Get()
    {
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
        var dtos =  _packageService.GetPackagesAdmin();
        return Ok(dtos);
    }

    [HttpPut("/api/Package/update-package")]
    public async Task<IActionResult> UpdatePackage([FromBody] UpdatePackageDto updatePackageDto)
    {
        if (updatePackageDto == null)
            return BadRequest("Package data is not correct !");
        return Ok(await _packageService.UpdatePackage(updatePackageDto));
    }

    [HttpDelete("/api/Package/delete-package/{packageId}")]
    public async Task<IActionResult> DeletePackage(Guid packageId)
    {
       
        return Ok(await _packageService.DeletePackage(packageId));
    }

}