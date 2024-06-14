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
            .WithStatusCode(401)
            .WithErrorMessage("You are not authorized to create a contest")
            .ThrowIfNull(_currentUser.Id)
            .ThrowIf(!Guid.TryParse(_currentUser.Id, out var userIdAsGuid));

        var minTimeToStart = DateTime.Now.AddMinutes(30);
        var minDuration = TimeSpan.FromMinutes(30);
        var court = await _courtRepository.GetAsyncAsNoTracking(c => c.Id == request.CourtId, cancellationToken);
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
        contest.MaxPlayer = 2;
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
}
