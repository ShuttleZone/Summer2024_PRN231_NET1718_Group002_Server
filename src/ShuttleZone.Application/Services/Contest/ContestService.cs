using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public class ContestService : IContestService
{
    private readonly IContestRepository _contestRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContestService(IContestRepository contestRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _contestRepository = contestRepository;
        _unitOfWork = unitOfWork;
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

    public DtoContestResponse? GetContestByContestId(Guid userId)
    {
        var queryableContest = _contestRepository.Find(c => c.Id == userId)
            .Include(c => c.UserContests)
            .ThenInclude(uc => uc.Participant)
            .ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider).FirstOrDefault();
           
        // var dtoContest = queryableContest.ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);
    
        return queryableContest;
    }

    public IQueryable<Contest> GetContestDetail(Guid contestId)
    {
        var contest = _contestRepository.Find(c => c.Id == contestId)
            .Include(c => c.UserContests)
            .ThenInclude(uc => uc.Participant);

        var dtoContest = contest.ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return contest;
    }

    public async Task<DtoContestResponse> CreateContestAsync(CreateContestRequest request, CancellationToken cancellationToken)
    {
        var contest = _mapper.Map<Contest>(request);

        await _contestRepository.AddAsync(contest, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        var response = _mapper.Map<DtoContestResponse>(contest);
        return response;
    }
}
