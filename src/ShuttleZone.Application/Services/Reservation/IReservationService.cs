using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebResponses.ReservationDetails;
using ShuttleZone.Domain.WebResponses.Reservations;


namespace ShuttleZone.Application.Services.Reservation
{
    public interface IReservationService
    {
        IQueryable<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser);
        IQueryable<ReservationResponse> GetMyReservation(Guid currentUser);

        Task<bool> CreateReservation(CreateReservationRequest request, Guid? currentUser = null, bool isStaff = true);
        Task CancelReservation(Guid reservationId);
        Task CancelReservationDetail(int reservationDetailId);

        bool HasOverlappingReservation(Guid? courtId, DateTime startTime, DateTime endTime);
    }
}
