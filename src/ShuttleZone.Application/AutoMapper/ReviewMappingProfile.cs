using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;

namespace ShuttleZone.Application.AutoMapper;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<Review, DtoCreateReview>();
        CreateMap<DtoCreateReview, Review>();

    }
}