using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Contest;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.Services;

public interface IContestService
{
    IQueryable<DtoContestResponse> GetContests();
    DtoContestResponse? GetContestByContestId(Guid contestId);
    IQueryable<DtoContestResponse?> GetMyContest(Guid userId);
    IQueryable<Contest> GetContestDetail(Guid contestId);
    Task<DtoContestResponse> CreateContestAsync(CreateContestRequest request, CancellationToken cancellationToken);
    IQueryable<DtoContestResponse> GetMyClubContests(Guid clubId);
    IQueryable<DtoContestResponse> GetMyClubContestsStaff(Guid? clubId = null);

    Task JoinContest(Guid contestId, Guid userId);
    Task UpdateContestAsync(UpdateContestRequest request);
    Task<IQueryable<ContestResponse>> GetAllContestsAsync();
    Task<ContestResponse> GetContestAsync(Guid id);
}
