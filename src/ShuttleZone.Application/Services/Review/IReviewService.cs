using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Review;

namespace ShuttleZone.Application.DependencyInjection.Services.Review;
[AutoRegister]
public interface IReviewService
{
    Task<bool> DtoCreateReview(DtoCreateReview dtoCreateReview, Guid userId);

    Task<bool> DtoReplyReview(DtoReplyReview dtoReplyReview, Guid replyer);

    IQueryable<DtoReviewsResponse> GetReviews();

    IQueryable<DtoReviewsResponse> GetReviewByClubId(Guid clubId);
}