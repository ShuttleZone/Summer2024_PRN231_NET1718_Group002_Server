using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services.Notifications;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Contest;
using ShuttleZone.Domain.WebRequests.Notifications;
using ShuttleZone.Domain.WebResponses.Contest;
using ShuttleZone.Domain.WebResponses.Notifications;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public class ContestService(
    IMapper _mapper,
    IUnitOfWork _unitOfWork,
    IUser _currentUser,
    INotificationHubService _notificationHubService
    ) : IContestService
{
    public IQueryable<DtoContestResponse> GetContests()
    {
        var queryableClubs = _unitOfWork.ContestRepository
            .GetAll()
            .Include(c => c.Reservation)
            .Where(c => c.Reservation!.ReservationStatusEnum == ReservationStatusEnum.PAYSUCCEED);
        var dtoClubs = queryableClubs
            .ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return dtoClubs;
    }

    public DtoContestResponse? GetContestByContestId(Guid userId)
    {
        var queryableContest = _unitOfWork.ContestRepository.Find(c => c.Id == userId)
            .Include(c => c.UserContests)
            .ThenInclude(uc => uc.Participant)
            .Include(c => c.Reservation)
            .Include(c => c.Reservation!.ReservationDetails)
            .ThenInclude(rd => rd.Court);

        var dtoReturn = queryableContest.ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider).FirstOrDefault();

        // var dtoContest = queryableContest.ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider);

        return dtoReturn;
    }

    public  List<DtoContestResponse?> GetMyContest(Guid userId)
    {
        var myContests = _unitOfWork.ContestRepository.GetAll()
            .Where(c => c.UserContests.Select(uc => uc.ParticipantsId).Contains(userId))
            .Include(c => c.Reservation)
            .ThenInclude(r => r!.ReservationDetails)
            .ThenInclude(rd => rd.Court)
            .ThenInclude(c => c.Club)
            .Include(c => c.UserContests);  
            var dtos = _mapper.Map<List<DtoContestResponse?>>(myContests);
            return dtos;
    }

    public IQueryable<Contest> GetContestDetail(Guid contestId)
    {
        var contest = _unitOfWork.ContestRepository.Find(c => c.Id == contestId)
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

        var court = await _unitOfWork.CourtRepository
            .FindAsNoTracking(c => c.Id == request.CourtId)
            .Include(c => c.Club)
            .FirstOrDefaultAsync(cancellationToken);

        HttpException.New()
            .WithStatusCode(404)
            .WithErrorMessage($"Court {request.CourtId} does not exist.")
            .ThrowIfNull(court);

        foreach (var slot in request.ContestSlots)
        {
            var courtBooked = await _unitOfWork.ReservationDetailRepository
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
            reservation.TotalPrice += court.Price;
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

        await _unitOfWork.ContestRepository.AddAsync(contest, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        var response = _mapper.Map<DtoContestResponse>(contest);
        return response;
    }

    public IQueryable<DtoContestResponse> GetMyClubContests(Guid clubId)
    {
        HttpException.New()
            .WithStatusCode(401)
            .WithErrorMessage("You need to log in to view this page.")
            .ThrowIfNull(_currentUser.Id)
            .ThrowIf(!Guid.TryParse(_currentUser.Id, out var userIdAsGuid))
            .WithStatusCode(403)
            .WithErrorMessage("You are not authorized to view this page.")
            .ThrowIf(_currentUser.Role != ShuttleZone.Domain.Constants.SystemRole.Manager);

        var contestsResponse = _unitOfWork.ClubRepository
            .FindAsNoTracking(c => c.OwnerId == userIdAsGuid && c.Id == clubId)
            .SelectMany(c => c.Courts)
            .SelectMany(c => c.ReservationDetails)
            .Where(r => r.Reservation != null)
            .Select(r => r.Reservation)
            .Where(r => r.Contest != null)
            .Select(r => r.Contest)
            .ProjectTo<DtoContestResponse>(_mapper.ConfigurationProvider)
            .AsSplitQuery();

        return contestsResponse;
    }

    public async Task JoinContest(Guid contestId, Guid userId)
    {
        var contest = _unitOfWork.ContestRepository.Find(c => c.Id == contestId).Include(c => c.UserContests).FirstOrDefault()
            ?? throw new HttpException(400, $"Contest with id {contestId} is not existed");

        var isInPast = contest.ContestDate < DateTime.Now;
        if (isInPast)
            throw new HttpException(400, $"Contest with id {contestId} is already happened");

        if (contest.ContestStatus == ContestStatusEnum.Closed)
            throw new HttpException(400, $"Contest with id {contestId} is already closed");

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

        //check if contest is already updated, can not update       
        if (contest.ContestStatus == ContestStatusEnum.Closed)
        {
            throw new HttpException(400, $"Contest with id {request.Id} is already updated. Can not update one more time. Cause money has refunded to customer");
        }

        //validation for time, if contest does not happen, is not allowed update 
        if (contest.ContestDate > DateTime.Now)
            throw new HttpException(400, $"Contest with id {request.Id} is not happened, can not update");

        if (request.UserContests!.Count() == 2)
        {
            //set winner for contest, who has larger point
            var winner = request.UserContests!.OrderByDescending(uc => uc.Point).First();
            winner.isWinner = true;
        }

        var winners = request.UserContests.Where(uc => uc.isWinner);
        var test = winners.Count();
        if (winners.Count() > contest.UserContests.Count()/2)
            throw new HttpException(400, $"Total player is {contest.UserContests.Count()}. Only less or equal half of total player is winner allowed");

        foreach (var userContest in request.UserContests ?? new List<UserContestRequest>())
        {
            var UserContestExisted = contest.UserContests.FirstOrDefault(uc => uc.ParticipantsId == userContest.ParticipantsId);
            if (UserContestExisted == null)
                throw new HttpException(400, $"User with id {userContest.ParticipantsId} is not in this contest");
            UserContestExisted.isWinner = userContest.isWinner;
            UserContestExisted.Point = userContest.Point;
        }
        contest.ContestStatus = ContestStatusEnum.Closed;        

        //add later: refund money for winner
        //this can not be done now (with VNPAY) because with one contest, we can have multiple reservation, do not know which person to refund
        //update database to have contestId(optional field) in transaction table
        //_vnPayService.RefundPaymentAsync(contest.Reservation.Id, 0, VnPayConstansts.TOTAL_REFUND);

        //refund money to wallet of winner
       foreach (var winner in winners)
        {
            var refundAmount = contest.Reservation != null ? contest.Reservation.TotalPrice : 0;
            _unitOfWork.WalletRepository.UpdateWalletBalanceByUserId(winner.ParticipantsId, refundAmount);
            var transaction = new Domain.Entities.Transaction()
            {
                Id = new Guid(),
                PaymentMethod = PaymentMethod.WALLET,
                Amount = refundAmount,
                TransactionStatus = TransactionStatusEnum.SUCCESS,
            };
            var wallet = await _unitOfWork.WalletRepository.GetAsync(w => w.UserId==winner.ParticipantsId) ?? throw new HttpException(400, "Invalid wallet");
            wallet.Transactions.Add(transaction);
            _unitOfWork.TransactionRepository.Add(transaction);
            //notifiy to user
            var notificationRequest = new NotificationRequest
            {
                UserId = winner.ParticipantsId,
                Description = $"You have won the contest. You are have refunded {refundAmount} VND"
            };
            var notification = _notificationHubService.CreateNotification(notificationRequest);
            await _unitOfWork.NotificationRepository.AddAsync(notification);
            await _notificationHubService.SendNotificationAsync(winner.ParticipantsId, _mapper.Map<NotificationResponse>(notification));
           
        };
        try
        {
            await _unitOfWork.CompleteAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    public async Task<IQueryable<ContestResponse>> GetAllContestsAsync()
    {
        var contestQueryable = await _unitOfWork.ContestRepository.GetAllAsync();
        return contestQueryable.ProjectTo<ContestResponse>(_mapper.ConfigurationProvider);
    }

    public async Task<ContestResponse> GetContestAsync(Guid id)
    {
        var contest = (await _unitOfWork.ContestRepository.GetAllAsync())
            .Where(c => c.Id == id).FirstOrDefault() ?? throw new HttpException(400, $"Invalid contest with Id {id}");

        return _mapper.Map<ContestResponse>(contest);
    }
}
