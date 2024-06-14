using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.DependencyInjection.Services.Review;
using ShuttleZone.Domain.WebRequests;

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

}