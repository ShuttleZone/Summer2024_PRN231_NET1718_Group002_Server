using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.DependencyInjection.Services.Package;
using ShuttleZone.Domain.Constants;
using ShuttleZone.Domain.WebRequests.Packages;
using ShuttleZone.Domain.WebResponses.Package;

namespace ShuttleZone.Api.Controllers;

public class PackageController: BaseApiController
{
    private readonly IPackageService _packageService;
    private readonly IUser _user;
    public PackageController(IPackageService packageService, IUser user)
    {
        _packageService = packageService;
        _user = user;
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
    
    [HttpPut("/api/Package/update-package-status/{packageId}")]
    public async Task<IActionResult> UpdatePackageStatus([FromRoute] Guid packageId)
    {
        var result = await _packageService.UpdateStatus(packageId);
        if (result == true)
            return Ok(result);
        return BadRequest("Error in changing status !");
    }

    [HttpGet("/api/Package/getUserPackage")]
    [EnableQuery]
    public IActionResult GetUserPackage()
    {
        var userId = new Guid(_user.Id?? throw new ArgumentNullException());
        var result =  _packageService.GetCurrentUserPackage(userId);
        return Ok(result);
       
    }
    
    [HttpGet("/api/Package/getUserPackageHistory")]
    [EnableQuery]
    public IActionResult GetPackageHistory()
    {
        var userId = new Guid(_user.Id?? throw new ArgumentNullException());
        var result =  _packageService.GetUserPackageHistory(userId);
        return Ok(result);
       
    }

    [HttpPost("/api/Package/subPackage")]
    // [Authorize(Roles = SystemRole.Manager)]
    public async Task<IActionResult> SubPackage([FromBody] SubPackageDto subPackageDto)
    {
        var userId = new Guid(_user.Id?? throw new ArgumentNullException());
        var result = await _packageService.SubPackageManager(subPackageDto, userId);
        return Ok(result);
        
    }
    
    [HttpPut("/api/Package/unsubPackage")]
    public IActionResult UnSubPackage()
    {
        var userId = new Guid(_user.Id?? throw new ArgumentNullException());
        var result =  _packageService.UnSubPackageManager(userId);
        return Ok(result);
       
    }
}