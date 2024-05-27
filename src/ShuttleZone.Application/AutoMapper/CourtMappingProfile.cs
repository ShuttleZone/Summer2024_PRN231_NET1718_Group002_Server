using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.AutoMapper;

public class CourtMappingProfile : Profile
{
    public CourtMappingProfile()
    {
        CreateMap<Court, DtoCourtResponse>()
            .ForMember(x => x.ClubName, opt => opt.MapFrom(x => x.Club.ClubName));
    }
}