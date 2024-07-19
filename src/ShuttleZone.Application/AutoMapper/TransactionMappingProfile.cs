using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.Transactions;

namespace ShuttleZone.Application.AutoMapper
{
    public class TransactionMappingProfile: Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<Transaction, TransactionResponse>();
        }
    }
}
