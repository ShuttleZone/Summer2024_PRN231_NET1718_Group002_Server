using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Repositories.ReservationDetail;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.Services.ReservationDetail;
[AutoRegister]

public class ReservationDetailService : IReservationDetailService
{
    private readonly IReservationDetailRepository _reservationDetailRepository;
    private readonly IMapper _mapper;

    public ReservationDetailService(IReservationDetailRepository reservationDetailRepository, IMapper mapper)
    {
        _reservationDetailRepository = reservationDetailRepository;
        _mapper = mapper;
    }
    public IQueryable<DtoReservationDetail> GetClubReservationDetails(Guid clubId)
    {

        //Console.WriteLine(DateTime.Now);
        //var reservationDetails = _reservationDetailRepository.Find(x => x.Court.ClubId == clubId 
        //                                                                && (x.ReservationDetailStatus == ReservationStatusEnum.PENDING || x.ReservationDetailStatus == ReservationStatusEnum.PAYSUCCEED)
        //                                                                && x.StartTime >= DateTime.Now);

        /* 
         * Hai's function
         * 22/6/2024 nhi fixed: use the StartTime to compare with the current time, but the StartTime is the time that the reservation is started, not the time that the reservation is expired
         * I fix the query to get the reservation details that have status is PENDING and the expired time is greater than or equal to the current time
         * if i am wrong, please let me know
         */

        var reservationDetails = _reservationDetailRepository.GetAll()
           .Include(r => r.Reservation)
           .Where((x => x.Court.ClubId == clubId && (x.ReservationDetailStatus == ReservationStatusEnum.PENDING && x.Reservation.ExpiredTime > DateTime.Now)
                                                                       || x.ReservationDetailStatus == ReservationStatusEnum.PAYSUCCEED));

        return _mapper.ProjectTo<DtoReservationDetail>(reservationDetails);
    }
}