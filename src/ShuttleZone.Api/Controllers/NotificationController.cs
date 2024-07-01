using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Notifications;

namespace ShuttleZone.Api.Controllers
{
    public class NotificationController(INotificationService _notificationService) : BaseApiController
    {

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return await HandleResultAsync(
            async () => await _notificationService.GetNotifications(UserId).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }
        [HttpPut("read-noti")]
        public async Task<IActionResult> Put()
        {
            return await HandleResultAsync(
            async () => await _notificationService.ReadNotifications(UserId).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }
    }
}
