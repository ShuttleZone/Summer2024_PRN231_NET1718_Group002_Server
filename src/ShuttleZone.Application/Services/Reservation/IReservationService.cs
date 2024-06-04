using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.Services.Reservation
{
    public interface IReservationService
    {
        IQueryable<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser);
    }
}
