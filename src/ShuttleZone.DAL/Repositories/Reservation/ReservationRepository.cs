using ShuttleZone.Infrastructure.Data.Interfaces;
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.DAL.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
        {
        }
    }
}
