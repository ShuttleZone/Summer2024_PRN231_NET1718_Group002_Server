using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Wallets;

namespace ShuttleZone.Api.Controllers
{
    public class TransactionsController(IWalletService _walletService) : BaseApiController
    {
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _walletService.GetMyTransactionsAsync(UserId));
        }
    }
}
