using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Review;

namespace ShuttleZone.Application.AutoMapper;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<Review, DtoCreateReview>();
        CreateMap<DtoCreateReview, Review>();
        CreateMap<Review, DtoReplyReview>();
        CreateMap<DtoReplyReview, Review>();
        CreateMap<Review, DtoReviewsResponse>();
    }
}