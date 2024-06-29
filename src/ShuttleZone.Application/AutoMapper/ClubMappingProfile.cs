using AutoMapper;
using ShuttleZone.Common.Helpers;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Club;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;

namespace ShuttleZone.Application.AutoMapper;

public class ClubMappingProfile : Profile
{
    public ClubMappingProfile()
    {
        CreateMap<Club, DtoClubResponse>();
        CreateMap<Club, ClubRequestDetailReponse>();
            // .ForMember(dest=>dest.Status, opt=>opt.MapFrom(src=>src.ClubStatusEnum.ToString()));
        CreateMap<OpenDateInWeek, OpenDateInWeekResponse>();
        CreateMap<Review, DtoReviewResponse>();
        CreateMap<ClubImage, DtoClubImageResponse>();
        CreateMap<Court, DtoCourt>();
        CreateMap<Club, AcceptClubRequestDto>();
        CreateMap<OpenDateInWeek, DtoOpenDateInWeek>();
        CreateMap<CreateClubRequest, Club>()
            .ForMember(club => club.ClubDescription, opt => opt.MapFrom(x => x.ClubDescription))
            .ForMember(club => club.ClubName, opt => opt.MapFrom(x => x.BasicInformation.ClubName))
            .ForMember(club => club.ClubAddress, opt => opt.MapFrom(x => x.BasicInformation.ClubAddress))
            .ForMember(club => club.ClubPhone, opt => opt.MapFrom(x => x.BasicInformation.ClubPhone))
            .ForMember(club => club.OpenTime, opt => opt.MapFrom(x => DateTimeHelper.FormatToTimeOnly(x.Settings.OpenTime)))
            .ForMember(club => club.CloseTime, opt => opt.MapFrom(x => DateTimeHelper.FormatToTimeOnly(x.Settings.CloseTime)))
            .ForMember(club => club.MinDuration, opt => opt.MapFrom(x => x.Settings.MinDuration));
        CreateMap<Club, DtoClubManagement>()
            .ForMember(dto => dto.TotalCourt, opt => opt.MapFrom(x => x.Courts.Count))
            .ForMember(dto => dto.TotalReview, opt => opt.MapFrom(x => x.Courts.Count));
        // .ForMember(dto => dto.Rating, opt => opt.MapFrom(x => (x.Reviews.Sum(x => x.Rating))/(x.Reviews.Count)));
    }
}
