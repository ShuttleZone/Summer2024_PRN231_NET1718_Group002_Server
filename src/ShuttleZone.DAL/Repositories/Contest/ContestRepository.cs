using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Data;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Repositories;

public class ContestRepository : GenericRepository<Contest>, IContestRepository
{
    
    public ContestRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }


}