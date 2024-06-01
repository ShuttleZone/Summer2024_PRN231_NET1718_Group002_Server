using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.AutoMapper;

public class ContestMappingProfile : Profile
{
    public ContestMappingProfile()
    {
        CreateMap<Contest, DtoContestResponse>()
            .ForMember(c => c.UserContests,
                opt => opt.MapFrom(src => src.UserContests));
        CreateMap<UserContest, UserContestDto>()
            .ForMember(c => c.ParticipantsId, opt => opt.MapFrom(src => src.ParticipantsId));
    }
    
}