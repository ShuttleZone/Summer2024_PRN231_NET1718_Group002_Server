using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.Services.Reservation
{
    [AutoRegister]
    public interface IReservationService
    {
        IQueryable<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser);
    }
}
