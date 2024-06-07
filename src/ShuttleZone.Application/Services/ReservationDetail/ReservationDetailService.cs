using AutoMapper;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Repositories.ReservationDetail;
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
        var reservationDetails = _reservationDetailRepository.Find(x => x.Court.ClubId == clubId);
        return _mapper.ProjectTo<DtoReservationDetail>(reservationDetails);
    }
}