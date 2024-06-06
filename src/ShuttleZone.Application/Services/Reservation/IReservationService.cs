using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebResponses.ReservationDetails;


namespace ShuttleZone.Application.Services.Reservation
{
    public interface IReservationService
    {
        IQueryable<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser);

        Task<bool> CreateReservation(CreateReservationRequest request, Guid? currentUser = null, bool isStaff = true);

        bool HasOverlappingReservation(Guid? courtId, DateTime startTime, DateTime endTime);
    }
}
