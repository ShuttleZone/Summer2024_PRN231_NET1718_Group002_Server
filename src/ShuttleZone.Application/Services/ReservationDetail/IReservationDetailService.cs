using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Application.Services.ReservationDetail;
[AutoRegister]
public interface IReservationDetailService
{
    IQueryable<DtoReservationDetail> GetClubReservationDetails(Guid clubId);
}