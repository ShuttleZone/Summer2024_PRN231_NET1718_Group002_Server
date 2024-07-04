using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;
using ShuttleZone.Domain.WebResponses.ShuttleZoneUser;
using ShuttleZone.Domain.WebResponses.Wallets;

namespace ShuttleZone.Application.AutoMapper;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, DtoUserProfile>();
        CreateMap<Wallet, WalletResponse>();
        CreateMap<User, DtoStaffProfile>()
            .ForMember(dto => dto.UserName, opt => opt.MapFrom(x => x.UserName))
            .ForMember(dto => dto.ProfileImage, opt => opt.MapFrom(x => x.ProfilePic));
        CreateMap<User, DtoClubStaff>()
            .ForMember(dto => dto.ProfileImage, opt => opt.MapFrom(x => x.ProfilePic))
            .ForMember(dto => dto.ClubAddress, opt => opt.MapFrom(x => x.Club!.ClubAddress))
            .ForMember(dto => dto.ClubName, opt => opt.MapFrom(x => x.Club!.ClubName));
    }
}