using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public interface IContestService
{
    IQueryable<DtoContestResponse> GetContests();
    IQueryable<DtoContestResponse> GetContestByUserId(Guid userId);

    IQueryable<Contest> GetContestDetail(Guid contestId);
}