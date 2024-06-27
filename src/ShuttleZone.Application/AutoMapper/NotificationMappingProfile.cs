using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Notifications;
using ShuttleZone.Domain.WebResponses.Notifications;

namespace ShuttleZone.Application.AutoMapper
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<NotificationRequest, Notification>();
            CreateMap<Notification, NotificationResponse>();
        }
    }
}
