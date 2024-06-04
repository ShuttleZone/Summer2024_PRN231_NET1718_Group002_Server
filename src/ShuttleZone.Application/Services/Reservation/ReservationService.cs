using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.Services.Reservation
{
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
    }
}
