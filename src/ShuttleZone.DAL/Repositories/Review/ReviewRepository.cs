using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.DependencyInjection.Repositories.Review;
[AutoRegister]

public class ReviewRepository : GenericRepository<Domain.Entities.Review>, IReviewRepository
{
    public ReviewRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }
}