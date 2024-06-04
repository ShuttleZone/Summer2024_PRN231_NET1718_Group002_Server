using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses.Court;
using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.AutoMapper;

public class CourtMappingProfile : Profile
{
    public CourtMappingProfile()
    {
        CreateMap<Court, DtoCourtResponse>()
            .ForMember(x => x.ClubName, opt => opt.MapFrom(x => x.Club.ClubName));
        CreateMap<ReservationDetail, DtoReservationDetail>()
            .ForMember(dto => dto.Date, opt => opt.MapFrom(x => x.StartTime.Date));
        CreateMap<CreateCourtRequest, Court>();
    }
}
