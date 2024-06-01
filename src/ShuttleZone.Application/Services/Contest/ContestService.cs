using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.Entities;
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

    public IQueryable<DtoContestResponse> GetContestByUserId(Guid userId)
    {
        var queryableContest = _contestRepository.GetAll()
            .Include(c => c.UserContests.Where(uc => uc.ParticipantsId == userId))
            .ThenInclude(uc => uc.Participant);
           
        var dtoContest = queryableContest.ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return dtoContest;
    }

    public IQueryable<Contest> GetContestDetail(Guid contestId)
    {
        var contest = _contestRepository.Find(c => c.Id == contestId)
            .Include(c => c.UserContests)
            .ThenInclude(uc => uc.Participant);

        var dtoContest = contest.ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return contest;
    }
}