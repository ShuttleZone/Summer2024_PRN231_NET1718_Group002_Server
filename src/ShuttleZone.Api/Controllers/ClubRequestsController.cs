using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services;
using ShuttleZone.Domain.WebResponses.Club;

namespace ShuttleZone.Api.Controllers
{
    public class ClubRequestsController: BaseApiController
    {
        private readonly IClubService _clubService;
        public ClubRequestsController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [EnableQuery]
        public ActionResult<IQueryable<CreateClubRequestDetailReponse>> Get()
        {
            return Ok(_clubService.GetCreateClubRequests());
        }

        [EnableQuery]
        public ActionResult<CreateClubRequestDetailReponse> Get([FromRoute] Guid key)
        {
            return Ok(_clubService.GetCreateClubRequests().FirstOrDefault(x=>x.Id==key));
        }
    }
}
