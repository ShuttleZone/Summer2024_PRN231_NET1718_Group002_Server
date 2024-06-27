using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services;

namespace ShuttleZone.Api.Controllers
{
    public class ContestDetailController(IContestService _contestService) : BaseApiController
    {
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return await HandleResultAsync(
            async () => await _contestService.GetAllContestsAsync().ConfigureAwait(false)
            ).ConfigureAwait(false);
        }
        [EnableQuery]
        public async Task<IActionResult> Get([FromRoute] Guid key)
        {
            return await HandleResultAsync(
            async () => await _contestService.GetContestAsync(key).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }
    }
}
