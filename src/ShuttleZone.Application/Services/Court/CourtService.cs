using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.DependencyInjection.Repositories.User;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses.Court;
using CourtEntity = ShuttleZone.Domain.Entities.Court;

namespace ShuttleZone.Application.Services.Court;

[AutoRegister]
public class CourtService : ICourtService
{
    private readonly ICourtRepository _courtRepository;
    private readonly IUserRepository _userRepository;
    private readonly IClubRepository _clubRepository;
    private readonly IUser _user;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourtService(
        ICourtRepository courtRepository,
        IClubRepository clubRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper, IUserRepository userRepository, IUser user)
    {
        _courtRepository = courtRepository;
        _clubRepository = clubRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userRepository = userRepository;
        _user = user;
    }

    public async Task<DtoCourtResponse> CreateCourtAsync(CreateCourtRequest request, CancellationToken cancellationToken)
    {
        var clubExists = await _clubRepository.ExistsAsync(x => x.Id == request.ClubId, cancellationToken);
        if (!clubExists)
            throw new Exception("Club does not exist");

        var court = _mapper.Map<CourtEntity>(request);
        court.Created = DateTime.Now;
        court.CreatedBy = "Admin";
        court.LastModified = DateTime.Now;
        await _courtRepository.AddAsync(court, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        var createdCourt = await _courtRepository.Find(x => x.Id == court.Id)
            .ProjectTo<DtoCourtResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        ArgumentNullException.ThrowIfNull(createdCourt, "Court not created");

        return createdCourt;
    }

    public bool DisableCourt(Guid courtId)
    {
        var court = _courtRepository.Get(c => c.Id == courtId);
        try
        {
            if (court != null)
            {
                if (court.CourtStatus != CourtStatus.Unavailable)
                {
                    court.CourtStatus = CourtStatus.Unavailable;
                    _courtRepository.Update(court);
                    return true;
                }else if (court.CourtStatus != CourtStatus.Available)
                {
                    court.CourtStatus = CourtStatus.Available;
                    _courtRepository.Update(court);
                    return true;
                }
                
            }
            throw new KeyNotFoundException();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public bool MaintainCourt(Guid courtId)
    {
        var staff = _userRepository.Get(x => x.Id.ToString() == _user.Id) ?? throw new Exception("Invalid Staff");
        var court = _courtRepository.GetAll().FirstOrDefault(c => c.Id == courtId);

        if (court == null) throw new HttpException(404,$"Không tìm thấy sân {courtId}");
        // if (court.CourtStatus != CourtStatus.Available) throw new HttpException(409, $"Không thể bảo trì sân này vì sân vẫn chưa được hoạt động");
        court.CourtStatus = CourtStatus.Maintain;
        court.LastModified = DateTime.Now;
        court.LastModifiedBy = staff.UserName;
        _courtRepository.Update(court);
        return true;
    }

    public IQueryable<DtoCourtResponse> GetAllCourts()
    {
        var courts = _courtRepository.GetAll()
            .Include(x => x.Club)
            .Include(x => x.ReservationDetails);
        var dtoCourtResponses =  _mapper.ProjectTo<DtoCourtResponse>(courts);
        return dtoCourtResponses;
    }

    public  DtoCourtResponse GetCourtById(Guid key)
    {
        var court =  _courtRepository.Find(x => x.Id == key)
            .Include(x => x.Club)
            .Include(x => x.ReservationDetails).FirstOrDefault();
        return _mapper.Map<DtoCourtResponse>(court);
    }
}
