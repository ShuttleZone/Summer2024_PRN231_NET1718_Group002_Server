using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.ShuttleZoneUser;
using ShuttleZone.Domain.WebResponses.Wallets;

namespace ShuttleZone.Application.AutoMapper;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, DtoUserProfile>();
        CreateMap<Wallet, WalletResponse>();
    }
}