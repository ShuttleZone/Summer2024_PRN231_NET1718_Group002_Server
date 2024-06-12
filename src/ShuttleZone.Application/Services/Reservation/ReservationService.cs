﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebResponses.ReservationDetails;
using ShuttleZone.Domain.WebResponses.Reservations;

namespace ShuttleZone.Application.Services.Reservation
{
    [AutoRegister]
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> CreateReservation(CreateReservationRequest request, Guid? currentUser = null, bool isStaff = true)
        {
            var requestEntity = _mapper.Map<ShuttleZone.Domain.Entities.Reservation>(request);
            if (!isStaff)
            {
                var user = await _userManager.FindByIdAsync(currentUser.ToString()
                                                            ?? throw new ArgumentNullException("UserId is null"))
                    ?? throw new InvalidOperationException("User not found");
                requestEntity.CustomerId = currentUser;
            }


            if (request.ReservationDetails == null || !request.ReservationDetails.Any())
            {
                throw new ArgumentException("At least one ReservationDetail is required.");
            }
            else
            {
                foreach (var detail in request.ReservationDetails)
                {

                    if (detail.StartTime < DateTime.Now.AddMinutes(30))
                    {
                        throw new ArgumentException("That reservations can only be made for a time at least 30 minutes in the future.");
                    }
                    if (detail.StartTime >= detail.EndTime)
                    {
                        throw new ArgumentException("StartTime must be less than EndTime for ReservationDetails.");
                    }

                    var courtExisted = _unitOfWork.CourtRepository.Exists(c => c.Id == detail.CourtId);
                    if (!courtExisted)
                    {
                        throw new InvalidOperationException($"Court {detail.CourtId} does not exist.");
                    }

                    var hasOverlap = HasOverlappingReservation(detail.CourtId, detail.StartTime, detail.EndTime);
                    if (hasOverlap)
                    {
                        throw new InvalidOperationException($"Court {detail.CourtId} is already booked during the requested time.");
                    }
                }
            }
            requestEntity.ExpiredTime = requestEntity.BookingDate.AddMinutes(10);
            await _unitOfWork.ReservationRepository.AddAsync(requestEntity);
            var addSuccess = await _unitOfWork.Complete();
            return addSuccess;
        }

        public IQueryable<ReservationResponse> GetMyReservation(Guid currentUser)
        {
            var reservationsQuery = _unitOfWork.ReservationRepository.GetAll()
                .Where(r => r.CustomerId == currentUser)
                .Include(r => r.ReservationDetails)
                .ThenInclude(rd => rd.Court);

            var reservationsResponse = reservationsQuery
                .ProjectTo<ReservationResponse>(_mapper.ConfigurationProvider);

            return reservationsResponse;
        }

        public IQueryable<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser)
        {
            var reservationDetailsQuery = _unitOfWork.ReservationRepository.GetAll()
                .Where(r => r.CustomerId == currentUser)
                .Include(r => r.ReservationDetails)
                .SelectMany(r => r.ReservationDetails);

            var reservationDetailsResponse = reservationDetailsQuery
                .ProjectTo<ReservationDetailsResponse>(_mapper.ConfigurationProvider);

            return reservationDetailsResponse;
        }

        public bool HasOverlappingReservation(Guid? courtId, DateTime startTime, DateTime endTime)
        {
            return _unitOfWork.ReservationDetailRepository.GetAll().Include(d => d.Reservation).
                                Any(d => (d.ReservationDetailStatus == Domain.Enums.ReservationStatusEnum.PAYSUCCEED
                                || (d.ReservationDetailStatus == Domain.Enums.ReservationStatusEnum.PENDING
                                && d.Reservation.ExpiredTime < DateTime.Now)) && d.CourtId == courtId &&
                                                         d.StartTime < endTime &&
                                                         d.EndTime > startTime);
        }
    }
}
