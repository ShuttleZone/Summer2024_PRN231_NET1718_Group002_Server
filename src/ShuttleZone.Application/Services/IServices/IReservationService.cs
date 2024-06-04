using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.Services.IServices
{
    public interface IReservationService
    {
        IQueryable<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser);
    }
}
