using ShuttleZone.Application.Services.IServices;
using ShuttleZone.DAL.Common.Interfaces;

namespace ShuttleZone.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork  _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*public Task<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser)
        {
            //_unitOfWork.ReservationRepository.Get
            return;
        }*/
    }
}
