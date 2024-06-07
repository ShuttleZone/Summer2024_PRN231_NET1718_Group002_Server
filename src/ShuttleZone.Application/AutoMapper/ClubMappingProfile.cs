using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;

namespace ShuttleZone.Application.AutoMapper;

public class ClubMappingProfile : Profile
{
    public ClubMappingProfile()
    {
        CreateMap<Club, DtoClubResponse>();
        CreateMap<Club, CreateClubRequestDetailReponse>();
        CreateMap<Club, CreateClubRequestResponse>();
        CreateMap<OpenDateInWeek, OpenDateInWeekResponse>();
        CreateMap<Review, DtoReviewResponse>();
        CreateMap<ClubImage, DtoClubImageResponse>();
        CreateMap<Court, DtoCourt>();
        CreateMap<Club, AcceptClubRequestDto>();
    }
}
