using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.DependencyInjection.Repositories.Review;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.DAL.Repositories.ReservationDetail;
using ShuttleZone.DAL.Repositories.Transaction;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Common.Implementations
{
    [AutoRegister]
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
        public IClubRepository ClubRepository => new ClubRepository(_context, _readOnlyContext);
        public IReservationDetailRepository ReservationDetailRepository => new ReservationDetailRepository(_context, _readOnlyContext);
        public ICourtRepository CourtRepository => new CourtRepository(_context, _readOnlyContext);
        public ITransactionRepository TransactionRepository => new TransactionRepository(_context, _readOnlyContext);
        public IReviewRepository ReviewRepository  => new ReviewRepository(_context,_readOnlyContext);
        public IContestRepository ContestRepository => new ContestRepository(_context, _readOnlyContext);
        public async Task<bool> Complete()
        {
            return await Task.Run(() => _context.SaveChanges()) > 0;
        }

        public async Task<bool> CompleteAsync(CancellationToken cancellationToken = default)
        {
            var changes = await _context.SaveChangesAsync(cancellationToken);
            var saveChangesSuccessfully = changes > 0;
            return saveChangesSuccessfully;
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
