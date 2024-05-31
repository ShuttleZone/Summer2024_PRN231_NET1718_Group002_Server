using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.AutoMapper;

public class ContestMappingProfile : Profile
{
    public ContestMappingProfile()
    {
        CreateMap<Contest, DtoContestResponse>()
            .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.Participants));;
        CreateMap<UserContest, DtoContestResponse.UserContestDTO>();
        CreateMap<User, DtoContestResponse.UserContestDTO>();
            
    }
    
}