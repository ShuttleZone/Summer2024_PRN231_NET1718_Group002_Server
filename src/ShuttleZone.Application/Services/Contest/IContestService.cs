using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.Services;

public interface IContestService
{
    IQueryable<DtoContestResponse> GetContests();
}