using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Repositories.Court;

public class CourtRepository : GenericRepository<Domain.Entities.Court>, ICourtRepository
{
    public CourtRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }
}