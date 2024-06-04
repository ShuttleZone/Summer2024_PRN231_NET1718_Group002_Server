using ShuttleZone.Infrastructure.Data.Interfaces;
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Common.Attributes;

namespace ShuttleZone.DAL.Repositories
{
    [AutoRegister]
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
        {
        }
    }
}
