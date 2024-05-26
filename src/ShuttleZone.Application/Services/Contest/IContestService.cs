using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public interface IContestService
{
    IQueryable<DtoContestResponse> GetContests();
    IQueryable<DtoMyContestResponse> GetContestByUserId(Guid userId);
}