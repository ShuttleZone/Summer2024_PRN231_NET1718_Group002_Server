using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebResponses;

namespace ShuttleZone.Application.Services;

public class ClubService : IClubService
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IReadOnlyApplicationDbContext _readOnlyDbContext;
    private readonly IMapper _mapper;

    public ClubService(IApplicationDbContext dbContext, IReadOnlyApplicationDbContext readOnlyDbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _readOnlyDbContext = readOnlyDbContext;
        _mapper = mapper;
    }

    public Task<IQueryable<DtoClubResponse>> GetClubsAsync()
    {
        var clubs = _readOnlyDbContext
            .CreateReadOnlySet<Club>()
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider);

        return Task.FromResult(clubs);
    }
}
