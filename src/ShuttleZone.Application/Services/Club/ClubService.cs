using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.DependencyInjection.Repositories.User;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Club;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public class ClubService : IClubService
{
    private readonly IClubRepository _clubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClubService(IClubRepository clubRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _clubRepository = clubRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public DtoClubResponse? GetClub(Guid key)
    {
        var club = _clubRepository
            .Find(c => c.Id == key)
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return club;
    }
    
    public IQueryable<DtoClubResponse> GetClubs()
    {
        var queryableClubs = _clubRepository
            .GetAll();
        var dtoClubs = queryableClubs
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider);

        return dtoClubs;
    }

    public IQueryable<CreateClubRequestDetailReponse> GetCreateClubRequests()
    {
        var queryableClubs = _clubRepository
            .GetAll();

        return queryableClubs
            .ProjectTo<CreateClubRequestDetailReponse>(_mapper.ConfigurationProvider);        
    }

    public async Task<DtoClubResponse> AddClubAsync(CreateClubRequest request)
    {
        var owner = _userRepository.GetAll().FirstOrDefault() ?? throw new Exception("not have user");
        var club = _mapper.Map<Club>(request);
        club.OwnerId = owner.Id;
        await _clubRepository.AddAsync(club);
        await _unitOfWork.Complete();
        // club.OpenDateInWeeks
        
        return _mapper.Map<DtoClubResponse>(club);
    }
}
 