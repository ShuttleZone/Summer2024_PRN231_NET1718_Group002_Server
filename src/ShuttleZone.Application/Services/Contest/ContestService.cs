using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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

    public IQueryable<DtoMyContestResponse> GetContestByUserId(Guid userId)
    {
        var queryableContest = _contestRepository
            .Find(c => c.Participants.Any(u => u.Id == userId));
        var dtoContest = queryableContest.ProjectTo<DtoMyContestResponse>(_mapper.ConfigurationProvider);

        return dtoContest;
    }
}