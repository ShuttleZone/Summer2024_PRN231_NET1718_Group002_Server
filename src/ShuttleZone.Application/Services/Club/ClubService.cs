using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public class ClubService : IClubService
{
    private readonly IClubRepository _clubRepository;
    private readonly IMapper _mapper;

    public ClubService(IClubRepository clubRepository, IMapper mapper)
    {
        _clubRepository = clubRepository;
        _mapper = mapper;
    }

    public DtoClubResponse? GetClub(Guid key)
    {
        var club = _clubRepository
            .Find(c => c.Id == key)
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return club;
    }
    
    public IQueryable<DtoClubResponse> GetClubs()
    {
        var queryableClubs = _clubRepository
            .GetAll();
        var dtoClubs = queryableClubs
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider);

        return dtoClubs;
    }

    public IQueryable<CreateClubRequestDetailReponse> GetCreateClubRequests()
    {
        var queryableClubs = _clubRepository
            .GetAll();

        return queryableClubs
            .ProjectTo<CreateClubRequestDetailReponse>(_mapper.ConfigurationProvider);        
    }

    public AcceptClubRequestDto AcceptClubRequest(Guid ClubId)
    {
        var club = _clubRepository.Get(c => c.Id == ClubId);
        var clubRequestDto =  _mapper.Map<AcceptClubRequestDto>(club);
        return clubRequestDto;
    }
}
