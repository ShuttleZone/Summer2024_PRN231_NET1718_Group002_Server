using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.DependencyInjection.Services.Review;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses;

namespace ShuttleZone.Api.Controllers;

public class ReviewsController : BaseApiController
{

    private readonly IReviewService _reviewService;
    private readonly IUser _user;

    public ReviewsController(IReviewService reviewService, IUser user)
    {
        _reviewService = reviewService;
        _user = user;
    }

    [HttpPost("/api/Review/create-review")]
    public async Task<IActionResult> CreateReviewUser([FromBody] DtoCreateReview dtoCreateReview)
    {
        var userId = new Guid(_user.Id?? throw new ArgumentNullException());
        await _reviewService.DtoCreateReview(dtoCreateReview, userId);
        return Ok(dtoCreateReview);

    }

    [HttpPut("/api/Review/reply-review")]
    public async Task<IActionResult> ReplyReview([FromBody] DtoReplyReview reply)
    {
        var userId = new Guid(_user.Id?? throw new ArgumentNullException());
        await _reviewService.DtoReplyReview(reply, userId);
        return Ok(reply);
    }

    [EnableQuery]
    public ActionResult<DtoReviewResponse> Get()
    {
        var dtos = _reviewService.GetReviews();
        return Ok(dtos);
    }
    
    [EnableQuery]
    public ActionResult<DtoReviewResponse> Get([FromRoute] Guid key)
    {
        var dtos = _reviewService.GetReviewByClubId(key);
        return Ok(dtos);
    }

}