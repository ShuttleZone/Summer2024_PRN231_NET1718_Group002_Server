using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.Services.ReservationDetail;
public interface IReservationDetailService
{
    IQueryable<DtoReservationDetail> GetClubReservationDetails(Guid clubId);
}