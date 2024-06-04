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
            .ForMember(x => x.ClubName, opt => opt.MapFrom(x => x.Club.ClubName))
            .ForMember(dto => dto.OpenTime, opt => opt.MapFrom(x => x.Club.OpenTime))
            .ForMember(dto => dto.CloseTime, opt => opt.MapFrom(x => x.Club.CloseTime))
            .ForMember(dto => dto.MinDuration, opt => opt.MapFrom(x => x.Club.MinDuration));
        CreateMap<ReservationDetail, DtoReservationDetail>()
            .ForMember(dto => dto.StartTime, opt => opt.MapFrom(x => x.StartTime))
            .ForMember(dto => dto.EndTime, opt => opt.MapFrom(x => x.EndTime))
            .ForMember(dto => dto.CourtName, opt => opt.MapFrom(x => x.Court.Name))
            .ForMember(dto => dto.Date, opt => opt.MapFrom(x => x.StartTime.Date));
        CreateMap<CreateCourtRequest, Court>();
    }
}
