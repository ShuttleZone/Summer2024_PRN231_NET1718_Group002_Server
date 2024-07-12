using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Application.Services.File;
using ShuttleZone.DAL.DependencyInjection.Repositories.User;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Club;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;
using ShuttleZone.Application.Services.Token;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Common.Exceptions;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public class ClubService : IClubService
{
    private readonly IClubRepository _clubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IUser _currentUser;
    private readonly IUnitOfWork _unitOfWork;

    public ClubService(
        IClubRepository clubRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IFileService fileService,
        ITokenService tokenService,
        IUser currentUser
    )
    {
        _clubRepository = clubRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _fileService = fileService;
        _tokenService = tokenService;
        _currentUser = currentUser;
    }

    public DtoClubResponse? GetClub(Guid key)
    {
        var club = _clubRepository
            //.Find(c => c.Id == key && (c.ClubStatusEnum == ClubStatusEnum.Open || c.ClubStatusEnum == ClubStatusEnum.CreateRequestAccepted))
            .Find(c => c.Id == key)

            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return club;
    }

    public IQueryable<DtoClubResponse> GetClubs()
    {
        var queryableClubs = _clubRepository
            //.Find(c => c.ClubStatusEnum == ClubStatusEnum.Open || c.ClubStatusEnum == ClubStatusEnum.CreateRequestAccepted);
            .Find(c => true);

        var dtoClubs = queryableClubs
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider);
        return dtoClubs;
    }

    public IQueryable<ClubRequestDetailReponse> GetCreateClubRequests()
    {
        var queryableClubs = _clubRepository
            .GetAll();

        return queryableClubs
            .ProjectTo<ClubRequestDetailReponse>(_mapper.ConfigurationProvider);
    }


    public bool AcceptClubRequest(Guid ClubId)
    {
        var club = _clubRepository.Get(c => c.Id == ClubId);
        if (club != null)
        {
            club.ClubStatusEnum = ClubStatusEnum.CreateRequestAccepted;
            _clubRepository.Update(club);
            return true;
        }
        return false;
    }
    
    public bool RejectClubRequest(Guid ClubId)
    {
        var club = _clubRepository.Get(c => c.Id == ClubId);
        if (club != null)
        {
            club.ClubStatusEnum = ClubStatusEnum.CreateRequestDenied;
            _clubRepository.Update(club);
            return true;
        }
        return false;
    }

    public async Task<DtoClubResponse> AddClubAsync(CreateClubRequest request)
    {
        if (string.IsNullOrEmpty(request.CourtsJson))
            throw new HttpException(statusCode: 400, message: "CCâu lạc bộ cần có ít nhất 1 sân.");
        
        if (_currentUser.Id == null)
            throw new Exception("Người dùng không tồn tại!");
        var owner = _userRepository.Find(x => x.Id == Guid.Parse(_currentUser.Id))
            .Include(x => x.PackageUsers)
            .FirstOrDefault() ?? throw new Exception("Người dùng không tồn tại.");

        if (!IsWithinSubscription(owner))
            throw new HttpException(400,"Bạn không có gói đăng ký nào hoặc gói đăng ký đã hết hạn.");
             
        var club = _mapper.Map<Club>(request);
        club.OwnerId = owner.Id;
        await _clubRepository.AddAsync(club);
        await _unitOfWork.CompleteAsync();
        // club.OpenDateInWeeks
        var daysInWeek = request.DaysInWeekOpen
            .Select(x => new OpenDateInWeek { Date = x });
        var images = await _fileService.UploadMultipleFileAsync(request.Files);
        var clubImages = images.Select(x => new ClubImage() { ImageUrl = x });
        club.OpenDateInWeeks = daysInWeek.ToList();
        club.ClubImages = clubImages.ToList();
        var deserializedObject = JsonConvert.DeserializeObject<List<CourtRequest>>(request.CourtsJson);
        var courts = deserializedObject!.Select(x => new Domain.Entities.Court
        {
            ClubId = club.Id,
            Name = x.CourtName,
            CourtStatus = x.CourtStatus,
            CourtType = x.CourtType,
            Price = x.Price,
            CreatedBy = owner.UserName,
            LastModified = DateTime.Now,
            LastModifiedBy = owner.UserName
        });
        foreach (var court in courts)
        {
            club.Courts.Add(court);
        }
        _clubRepository.Update(club);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<DtoClubResponse>(club);
    }

    public  IQueryable<DtoClubStaff> GetMyStaff()
    {
        var owner = _userRepository.Find(x => x.Id.ToString() == _currentUser.Id)
            .Include(x => x.Clubs)
            .FirstOrDefault()  ?? throw new HttpException(statusCode: 404, message:"Người dùng không tồn tại!");
        var userClubIds = owner.Clubs.Select(x => x.Id).ToList();
        var staff =  _userRepository.Find(x => x.ClubId != null && userClubIds.Contains((Guid)x.ClubId));
        return _mapper.ProjectTo<DtoClubStaff>(staff);
    }

    public IQueryable<DtoClubResponse> GetMyClubs()
    {
        var userId = _currentUser.Id;
        ArgumentNullException.ThrowIfNull(userId, nameof(userId));
        var queryableClubs = _clubRepository
            .Find(c => c.OwnerId == new Guid(userId) )
            // .GetAll()
            // .Where(c => c.OwnerId == new Guid(userId))
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider);

        return queryableClubs;
    }

    private bool IsWithinSubscription(User user)
    {
        return user.PackageUsers.Count != 0 && user.PackageUsers.Any(userPackageUser => userPackageUser.EndDate >= DateTime.Now && userPackageUser.PackageUserStatus == PackageUserStatus.VALID);
    }

    public async Task<DtoClubResponse> GetMyWorkingClubAsync()
    {
        var userId = _currentUser.Id;
        HttpException.New()
            .WithStatusCode(401)
            .WithErrorMessage("Bạn không có quyền truy cập.")
            .ThrowIfNull(userId)
            .ThrowIf(!Guid.TryParse(userId, out var userIdAsGuid));
        
        var club = await _clubRepository
            .FindAsNoTracking(
                x => x.Staffs
                    .Select(staff => staff.Id)
                    .Contains(userIdAsGuid)
            )
            .ProjectTo<DtoClubResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        HttpException.New()
            .WithStatusCode(404)
            .WithErrorMessage("Không tìm thấy câu lạc bộ.")
            .ThrowIfNull(club);

        return club;
    }
}
