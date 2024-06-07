using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Repositories.Transaction
{
    public class TransactionRepository : GenericRepository<ShuttleZone.Domain.Entities.Transaction>, ITransactionRepository
    {
        public TransactionRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
        {
        }
    }
}
