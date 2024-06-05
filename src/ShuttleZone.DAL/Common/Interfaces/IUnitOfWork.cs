using ShuttleZone.DAL.Repositories;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.DAL.Repositories.ReservationDetail;

namespace ShuttleZone.DAL.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IReservationRepository ReservationRepository { get; }
        IReservationDetailRepository ReservationDetailRepository { get; }
        ICourtRepository CourtRepository { get; }
        Task<bool> Complete();
    }
}
