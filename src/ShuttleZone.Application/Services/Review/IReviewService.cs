using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebRequests;

namespace ShuttleZone.Application.DependencyInjection.Services.Review;
[AutoRegister]
public interface IReviewService
{
    Task<bool> DtoCreateReview(DtoCreateReview dtoCreateReview, Guid userId);
}