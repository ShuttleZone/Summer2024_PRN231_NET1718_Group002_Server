using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Common.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IApplicationDbContext _context;
        private readonly IReadOnlyApplicationDbContext _readOnlyContext;
        public UnitOfWork(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext)
        {
            _context = context;
            _readOnlyContext = readOnlyContext;
        }

        public IReservationRepository ReservationRepository => new ReservationRepository(_context, _readOnlyContext);

        public async Task<bool> Complete()
        {
            return await Task.Run(() => _context.SaveChanges()) > 0;
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}