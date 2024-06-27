using ShuttleZone.DAL.DependencyInjection.Repositories.Package;
using ShuttleZone.DAL.DependencyInjection.Repositories.Review;
using ShuttleZone.DAL.DependencyInjection.Repositories.User;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.DAL.Repositories.ReservationDetail;
using ShuttleZone.DAL.Repositories.Transaction;
using ShuttleZone.DAL.Repositories.Wallets;

namespace ShuttleZone.DAL.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IReservationRepository ReservationRepository { get; }
        IReservationDetailRepository ReservationDetailRepository { get; }
        ICourtRepository CourtRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IContestRepository ContestRepository { get; }
        IClubRepository ClubRepository { get; }
        IWalletRepository WalletRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IPackageRepository PackageRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> CompleteAsync(CancellationToken cancellationToken = default);      

    }
}
