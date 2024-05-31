using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.AutoMapper
{
    public class ReservationDetailsMappingProfile : Profile
    {
        public ReservationDetailsMappingProfile()
        {
            CreateMap<ReservationDetail, ReservationDetailsResponse>();

        }
    }
}
