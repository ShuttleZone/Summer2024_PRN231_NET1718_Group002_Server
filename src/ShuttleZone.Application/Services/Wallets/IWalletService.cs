using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Wallets;

namespace ShuttleZone.Application.Services.Wallets
{
    public interface IWalletService
    {
        Task<IQueryable<WalletResponse>> GetWalletsAsync();
        Task<WalletResponse> GetMyWalletAsync(Guid currentUserId);
        Task PutWalletAsync(Guid walletId, VnPayRequest request);
    }
}
