using ShuttleZone.Common.Attributes;

namespace ShuttleZone.Application.DependencyInjection.Services.Contest;

[AutoRegister]
public interface IContestService
{
    ICollection<Domain.Entities.Contest> GetContests();
}