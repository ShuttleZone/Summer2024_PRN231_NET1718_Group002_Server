using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.Services;

public class ContestService : IContestService
{
    private readonly IContestRepository _contestRepository;
    private readonly IMapper _mapper;

    public ContestService(IContestRepository contestRepository, IMapper mapper)
    {
        _contestRepository = contestRepository;
        _mapper = mapper;
    }

    public IQueryable<DtoContestResponse> GetContests()
    {
        var queryableClubs = _contestRepository
            .GetAll();
        var dtoClubs = queryableClubs
            .ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return dtoClubs;
    }
}