using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Repositories.Notifications
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
        {
        }
    }
}
