using AutoMapper;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;

namespace ShuttleZone.Application.AutoMapper
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<VnPayQueryDrResponse, VnPayRefundRequest>();
        }
    }
}
