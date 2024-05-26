using ShuttleZone.Domain.Entities;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Common.Attributes;

namespace ShuttleZone.DAL.Repositories
{
    [AutoRegister]
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
    }
}
