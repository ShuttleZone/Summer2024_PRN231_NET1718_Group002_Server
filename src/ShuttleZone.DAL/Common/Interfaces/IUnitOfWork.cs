using ShuttleZone.DAL.Repositories;

namespace ShuttleZone.DAL.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IReservationRepository ReservationRepository { get; }
        Task<bool> Complete();
        Task<bool> Complete(CancellationToken cancellationToken = default);
    }
}
