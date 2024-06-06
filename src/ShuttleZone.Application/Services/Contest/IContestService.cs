using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.Services;

public interface IContestService
{
    IQueryable<DtoContestResponse> GetContests();
    DtoContestResponse? GetContestByContestId(Guid contestId);

    IQueryable<Contest> GetContestDetail(Guid contestId);
}