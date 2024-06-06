using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.AutoMapper;

public class ContestMappingProfile : Profile
{
    public ContestMappingProfile()
    {
        CreateMap<Contest, DtoContestResponse>()
            .ForMember(dest => dest.UserContests, opt => opt.MapFrom(src => src.UserContests));
        CreateMap<UserContest, UserContestDto>()
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(c => c.Participant!.Fullname))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Participant!.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(c => c.Participant!.PhoneNumber))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(c => c.Participant!.Gender));
            
        CreateMap<User, UserContestDto>();
    }
    
}