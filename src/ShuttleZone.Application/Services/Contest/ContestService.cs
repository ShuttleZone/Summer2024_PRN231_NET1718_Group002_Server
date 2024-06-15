using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.DAL.Repositories.ReservationDetail;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Contest;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public class ContestService : IContestService
{
    private readonly IContestRepository _contestRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUser _currentUser;
    private readonly IReservationRepository _reservationRepository;
    private readonly IReservationDetailRepository _reservationDetailRepository;
    private readonly ICourtRepository _courtRepository;

    public ContestService
    (
        IContestRepository contestRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUser currentUser,
        IReservationRepository reservationRepository,
        IReservationDetailRepository reservationDetailRepository,
        ICourtRepository courtRepository
    )
    {
        _contestRepository = contestRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
        _reservationRepository = reservationRepository;
        _reservationDetailRepository = reservationDetailRepository;
        _courtRepository = courtRepository;
    }

    public IQueryable<DtoContestResponse> GetContests()
    {
        var queryableClubs = _contestRepository
            .GetAll();
        var dtoClubs = queryableClubs
            .ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return dtoClubs;
    }

    public DtoContestResponse? GetContestByContestId(Guid userId)
    {
        var queryableContest = _contestRepository.Find(c => c.Id == userId)
            .Include(c => c.UserContests)
            .ThenInclude(uc => uc.Participant)
            .ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider).FirstOrDefault();

        // var dtoContest = queryableContest.ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return queryableContest;
    }

    public IQueryable<Contest> GetContestDetail(Guid contestId)
    {
        var contest = _contestRepository.Find(c => c.Id == contestId)
            .Include(c => c.UserContests)
            .ThenInclude(uc => uc.Participant);

        var dtoContest = contest.ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return contest;
    }

    public async Task<DtoContestResponse> CreateContestAsync(CreateContestRequest request, CancellationToken cancellationToken)
    {
        HttpException.New()
            .WithStatusCode(400)
            .WithErrorMessage("Number of players is invalid.")
            .ThrowIf(request.MaxPlayer % 2 != 0);

        HttpException.New()
            .WithStatusCode(401)
            .WithErrorMessage("You are not authorized to create a contest")
            .ThrowIfNull(_currentUser.Id)
            .ThrowIf(!Guid.TryParse(_currentUser.Id, out var userIdAsGuid));

        var minTimeToStart = DateTime.Now.AddMinutes(30);
        var minDuration = TimeSpan.FromMinutes(30);
        
        var court = await _courtRepository
            .FindAsNoTracking(c => c.Id == request.CourtId)
            .Include(c => c.Club)
            .FirstOrDefaultAsync(cancellationToken);

        HttpException.New()
            .WithStatusCode(404)
            .WithErrorMessage($"Court {request.CourtId} does not exist.")
            .ThrowIfNull(court);

        foreach (var slot in request.ContestSlots)
        {
            var courtBooked = await _reservationDetailRepository
                .ExistsAsync(d => 
                    (
                        // check if reservation is already paid or still pending but not expired
                        d.ReservationDetailStatus == ReservationStatusEnum.PAYSUCCEED || 
                        (d.ReservationDetailStatus == ReservationStatusEnum.PENDING && d.Reservation.ExpiredTime > DateTime.Now)
                    ) &&
                    (
                        // check if time overlaps
                        d.StartTime < slot.EndTime &&
                        d.EndTime > slot.StartTime
                    ) &&
                    d.CourtId == request.CourtId
                );
            HttpException.New()
                .WithStatusCode(409)
                .WithErrorMessage($"Court is not open at the selected time ({slot.StartTime} - {slot.EndTime}).")
                .ThrowIf(slot.StartTime.TimeOfDay < court.Club.OpenTime.ToTimeSpan() || slot.EndTime.TimeOfDay > court.Club.CloseTime.ToTimeSpan())
                .WithErrorMessage($"Court can only be booked in at least 30 minutes in the future.")
                .ThrowIf(slot.StartTime < minTimeToStart)
                .WithErrorMessage($"Contest duration must be at least {minDuration} minutes.")
                .ThrowIf(slot.StartTime - slot.EndTime >= minDuration)
                .WithErrorMessage($"Court has already been booked from {slot.StartTime} to {slot.EndTime}.")
                .ThrowIf(courtBooked);
        }

        var reservation = new Domain.Entities.Reservation()
        {
            Id = Guid.NewGuid(),
            CustomerId = userIdAsGuid,
            BookingDate = DateTime.Now,
            ExpiredTime = DateTime.Now.AddMinutes(10),
            ReservationStatusEnum = ReservationStatusEnum.PENDING,
        };
        foreach (var slot in request.ContestSlots)
        {
            reservation.ReservationDetails.Add(new Domain.Entities.ReservationDetail()
            {
                Id = 0, // Just a placeholder, this value will be replaced by the database itself. Btw, ReservationDetail.Id should be a Guid, not an int.
                CourtId = request.CourtId,
                StartTime = slot.StartTime,
                EndTime = slot.EndTime,
                ReservationDetailStatus = ReservationStatusEnum.PENDING,
                Price = court.Price,
            });
        }

        var contestCreator = new UserContest
        {
            ParticipantsId = userIdAsGuid,
            isCreatedPerson = true,
            isWinner = false,
            Point = 0
        };
        var contest = _mapper.Map<Contest>(request);
        contest.ContestDate = request.ContestSlots.First().StartTime.Date;
        contest.ContestStatus = ContestStatusEnum.Open;
        contest.CreatedBy = _currentUser.Id;
        contest.Created = DateTime.UtcNow;
        contest.LastModified = DateTime.UtcNow;
        contest.UserContests.Add(contestCreator);
        contest.Reservation = reservation;

        await _contestRepository.AddAsync(contest, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        var response = _mapper.Map<DtoContestResponse>(contest);
        return response;
    }

    public async Task JoinContest(Guid contestId, Guid userId)
    {
        var contest = _unitOfWork.ContestRepository.Find(c => c.Id == contestId).Include(c => c.UserContests).FirstOrDefault()
            ?? throw new HttpException(400, $"Contest with id {contestId} is not existed");

        var isJoined = contest.UserContests.Exists(c => c.ParticipantsId == userId);
        if (isJoined)
            throw new HttpException(400, $"You are already in this contest");

        var isSlotRemaining = contest.MaxPlayer > contest.UserContests.Count();
        if (!isSlotRemaining)
            throw new HttpException(400, $"The contest is full slot");

        contest.UserContests.Add(
            new UserContest
            {
                ParticipantsId = userId,
                ContestId = contestId
            });

        await _unitOfWork.CompleteAsync();

    }

    public async Task UpdateContestAsync(UpdateContestRequest request)
    {
        var contest = _unitOfWork.ContestRepository.Find(c => c.Id == request.Id).Include(c => c.UserContests).FirstOrDefault()
            ?? throw new HttpException(400, $"Contest with id {request.Id} is not existed");
       
        //improve later: will add validation for time, if contest does not happen, is not allowed update 

        foreach (var userContest in request.UserContests ?? new List<UserContestRequest>())
        {
            var UserContestExisted = contest.UserContests.FirstOrDefault(uc => uc.ParticipantsId == userContest.ParticipantsId);
            if (UserContestExisted == null)
                throw new HttpException(400, $"User with id {userContest.ParticipantsId} is not in this contest");
            UserContestExisted.isWinner = userContest.isWinner;
            UserContestExisted.Point = userContest.Point;

        }         

        var winners = contest.UserContests.Where(uc=>uc.isWinner);
        if (winners.Count() > contest.UserContests.Count())
            throw new HttpException(400, $"Total player is {contest.UserContests.Count()}. Only less or equal half of total player is winner allowed");

        //add later: refund money for winner

        await _unitOfWork.CompleteAsync();
    }
}
