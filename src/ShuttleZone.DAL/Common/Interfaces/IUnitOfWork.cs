using ShuttleZone.DAL.Repositories;

namespace ShuttleZone.DAL.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IReservationRepository ReservationRepository { get; }
        Task<bool> Complete();
        IClubRepository ClubRepository { get; }
    }
}
