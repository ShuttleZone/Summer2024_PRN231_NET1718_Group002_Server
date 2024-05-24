using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Application.Services;

public class ClubService : IClubService
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IReadOnlyApplicationDbContext _readOnlyDbContext;

    public ClubService(IApplicationDbContext dbContext, IReadOnlyApplicationDbContext readOnlyDbContext)
    {
        _dbContext = dbContext;
        _readOnlyDbContext = readOnlyDbContext;
    }

    public Task<IQueryable<Club>> GetClubsAsync()
    {
        var clubs = _readOnlyDbContext
            .CreateReadOnlySet<Club>();

        return Task.FromResult(clubs);
    }
}
