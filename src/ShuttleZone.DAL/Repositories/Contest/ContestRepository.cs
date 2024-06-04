using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Repositories;

[AutoRegister]
public class ContestRepository : GenericRepository<Contest>, IContestRepository
{
    
    public ContestRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }


}
