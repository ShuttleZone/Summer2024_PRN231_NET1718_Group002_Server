using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Services.IServices;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Application.Services
{
    [AutoRegister]
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork  _unitOfWork;
        private readonly IMapper _mapper;
        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
