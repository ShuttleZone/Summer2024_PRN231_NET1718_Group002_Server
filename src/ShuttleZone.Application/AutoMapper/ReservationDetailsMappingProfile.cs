using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.Court;
using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.AutoMapper
{
    public class ReservationDetailsMappingProfile : Profile
    {
        public ReservationDetailsMappingProfile()
        {
            CreateMap<ReservationDetail, ReservationDetailsResponse>();
            CreateMap<ReservationDetail, DtoReservationDetail>()
                .ForMember(dto => dto.Date, opt => opt.MapFrom(x 
                    => x.StartTime.Date));
        }
    }
}
