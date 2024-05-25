using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.Repositories.IRepositories;
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
