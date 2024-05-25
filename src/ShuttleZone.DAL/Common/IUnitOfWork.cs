using ShuttleZone.DAL.Repositories.IRepositories;

namespace ShuttleZone.DAL.Common
{
    public interface IUnitOfWork
    {
        IReservationRepository ReservationRepository { get; }
        Task<bool> Complete();
       
    }
}
