using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.ReservationDetails;
using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebRequests.Transactions;
using ShuttleZone.Domain.WebResponses.Reservations;

namespace ShuttleZone.Application.AutoMapper
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<CreateReservationRequest, Reservation>();
            CreateMap<CreateReservationDetailRequest, ReservationDetail>();
            CreateMap<CreateTransactionRequest, Transaction>();
            CreateMap<Reservation, ReservationResponse>()
                .ForMember(dest => dest.CourtNames, opt => opt.MapFrom(src => src.ReservationDetails.Select(rd => rd.Court.Name)));
        }
    }
}
