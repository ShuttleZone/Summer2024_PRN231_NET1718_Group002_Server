using ShuttleZone.Application.Services.IServices;
using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.Services
{
    public class ReservationService : IReservationService
    {
        public ReservationService()
        {
            
        }
        public Task<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser)
        {
            throw new NotImplementedException();
        }
    }
}
