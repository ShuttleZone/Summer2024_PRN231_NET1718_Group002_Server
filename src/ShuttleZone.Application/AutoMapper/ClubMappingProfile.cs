using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses;

namespace ShuttleZone.Application.AutoMapper;

public class ClubMappingProfile : Profile
{
    public ClubMappingProfile()
    {
        CreateMap<Club, DtoClubResponse>();
        CreateMap<Review, DtoReviewResponse>();
        CreateMap<ClubImage, DtoClubImageResponse>();
    }
}
