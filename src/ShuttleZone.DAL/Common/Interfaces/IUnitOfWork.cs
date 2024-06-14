using ShuttleZone.DAL.DependencyInjection.Repositories.Review;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.DAL.Repositories.ReservationDetail;
using ShuttleZone.DAL.Repositories.Transaction;

namespace ShuttleZone.DAL.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IReservationRepository ReservationRepository { get; }
        IReservationDetailRepository ReservationDetailRepository { get; }
        ICourtRepository CourtRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task<bool> Complete();
        IClubRepository ClubRepository { get; }
        Task<bool> CompleteAsync(CancellationToken cancellationToken = default);
        IReviewRepository ReviewRepository { get; }

    }
}
