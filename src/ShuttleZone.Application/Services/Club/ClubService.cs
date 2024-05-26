using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.WebResponses;

namespace ShuttleZone.Application.Services;

public class ClubService : IClubService
{
    private readonly IClubRepository _clubRepository;
    private readonly IMapper _mapper;

    public ClubService(IClubRepository clubRepository, IMapper mapper)
    {
        _clubRepository = clubRepository;
        _mapper = mapper;
    }

    public IQueryable<DtoClubResponse> GetClubs()
    {
        var queryableClubs = _clubRepository
            .GetAll();
        var dtoClubs = queryableClubs
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider);

        return dtoClubs;
    }
}
