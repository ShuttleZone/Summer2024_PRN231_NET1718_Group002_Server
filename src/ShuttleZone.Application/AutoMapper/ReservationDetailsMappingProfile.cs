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
            
            CreateMap<ReservationDetail, DtoReservationDetail>()
                .ForMember(dto => dto.Date, opt => opt.MapFrom(x 
                    => x.StartTime.Date));
            CreateMap<ReservationDetail, ReservationDetailsResponse>()
                .ForMember(dest=>dest.ReservationDetailStatus, opt=>opt.MapFrom(src=>src.ReservationDetailStatus.ToString()))
                .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.Court.ClubId));
        }
    }
}
