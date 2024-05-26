using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Repositories;

namespace ShuttleZone.DAL.Common.Interfaces
{
    [AutoRegister]
    public interface IUnitOfWork
    {
        IReservationRepository ReservationRepository { get; }
        Task<bool> Complete();
    }
}
