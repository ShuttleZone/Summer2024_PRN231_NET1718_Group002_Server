using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Wallets;
using ShuttleZone.Domain.WebRequests.Payment;

namespace ShuttleZone.Api.Controllers
{
    public class WalletController(IWalletService _walletService) : BaseApiController
    {
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _walletService.GetWalletsAsync());
        }

        [HttpGet("api/Wallet/me")]
        public async Task<IActionResult> GetMe()
        {
            return Ok(await _walletService.GetMyWalletAsync(UserId));
        }

        [EnableQuery]
        public async Task<IActionResult> Put(Guid key, [FromBody]VnPayRequest request)
        {
            return Ok(await _walletService.PutWalletAsync(key, request));
        }
    }
}
