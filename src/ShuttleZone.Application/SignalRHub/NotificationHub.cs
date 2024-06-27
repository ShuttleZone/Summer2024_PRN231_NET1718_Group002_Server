using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace ShuttleZone.Application.SignalRHub
{
    [Authorize]
    public class NotificationHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> OnlineUsers = new ConcurrentDictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (userId != null)
            {
                OnlineUsers[userId] = Context.ConnectionId;
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            if (userId != null)
            {
                OnlineUsers.TryRemove(userId, out _);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public static bool TryGetConnectionId(string username, out string connectionId)
        {
            #pragma warning disable
            return OnlineUsers.TryGetValue(username, out connectionId);
        }
    }
}
