using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Repositories.ReservationDetail;
[AutoRegister]

public class ReservationDetailRepository : GenericRepository<Domain.Entities.ReservationDetail>, IReservationDetailRepository
{
    public ReservationDetailRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }
}