using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebResponses.ReservationDetails;
using System.Collections.Generic;

namespace ShuttleZone.Application.Services.Reservation
{
    [AutoRegister]
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateReservation(CreateReservationRequest request)
        {            
            var requestEntity = _mapper.Map<ShuttleZone.Domain.Entities.Reservation>(request);                   
            
            if (request.ReservationDetails == null || !request.ReservationDetails.Any())
            {
                throw new ArgumentException("At least one ReservationDetail is required.");              
            }
            else
            {
                foreach (var detail in request.ReservationDetails)
                {
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
           
            await _unitOfWork.ReservationRepository.AddAsync(requestEntity);
            var addSuccess = await _unitOfWork.Complete();
            return addSuccess;
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
            return  _unitOfWork.ReservationDetailRepository.GetAll().Any(d => d.CourtId == courtId &&
                                                         d.StartTime < endTime &&
                                                         d.EndTime > startTime);
        }
    }
}
