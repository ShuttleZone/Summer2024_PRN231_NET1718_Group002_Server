using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Infrastructure.Data.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Common.Attributes;

namespace ShuttleZone.DAL.Repositories;

[AutoRegister]
public class ClubRepository : GenericRepository<Club>, IClubRepository
{
    public ClubRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }
}
