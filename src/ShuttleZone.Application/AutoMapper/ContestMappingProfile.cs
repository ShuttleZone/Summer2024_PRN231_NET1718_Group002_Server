using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Contest;
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
        CreateMap<CreateContestRequest, Contest>();

        CreateMap<Contest, UpdateContestRequest>();          
        CreateMap<UserContest, UserContestRequest>();

        CreateMap<UpdateContestRequest, Contest>()
            .ForMember(dest => dest.UserContests, opt => opt.Ignore()); 
        CreateMap<UserContestRequest, UserContest>()
            .ForMember(dest => dest.isWinner, opt => opt.MapFrom(src => src.isWinner))
            .ForMember(dest => dest.Point, opt => opt.MapFrom(src => src.Point));

    }
}
