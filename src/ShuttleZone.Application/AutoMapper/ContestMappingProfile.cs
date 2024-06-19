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
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(r => r.BookingDate))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(r => r.TotalPrice))
            .ForMember(dest => dest.ReservationDetailsDtos, opt => opt.MapFrom(r => r.ReservationDetails));
        CreateMap<UserContest, UserContestDto>()
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(c => c.Participant!.Fullname))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Participant!.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(c => c.Participant!.PhoneNumber))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(c => c.Participant!.Gender));
        CreateMap<ReservationDetail, ReservationDetailsDto>()
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(rd => rd.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(rd => rd.EndTime))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(rd => rd.Price))
            .ForMember(dest => dest.Court, opt => opt.MapFrom(rd => rd.Court));
        CreateMap<Court, CourtDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name))
            .ForMember(dest => dest.Club, opt => opt.MapFrom(c => c.Club));
        CreateMap<Club, ClubDto>();
            
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
