using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.ReservationDetails;
using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebRequests.Transactions;

namespace ShuttleZone.Application.AutoMapper
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<CreateReservationRequest, Reservation>();
            CreateMap<CreateReservationDetailRequest, ReservationDetail>();
            CreateMap<CreateTransactionRequest, Transaction>();
        }
    }
}
