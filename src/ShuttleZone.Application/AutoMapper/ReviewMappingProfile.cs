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
        CreateMap<Review, DtoReviewsResponse>()
            // .ForMember(dest => dest.UserCreatedTime, opt => opt.MapFrom(c => c.Reviewer.))
            .ForMember(dest => dest.ClubDescription, opt => opt.MapFrom(c => c.Club!.ClubDescription))
            .ForMember(dest => dest.ClubPhone, opt => opt.MapFrom(c => c.Club!.ClubPhone))
            .ForMember(dest => dest.ClubAddress, opt => opt.MapFrom(c => c.Club!.ClubAddress))
            .ForMember(dest => dest.ClubName, opt => opt.MapFrom(c => c.Club!.ClubName));
    }
}