using ShuttleZone.Application.Services;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.DAL.Repositories;

public class ClubRepository : GenericRepository<Club>, IClubRepository
{
    public ClubRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }
}
