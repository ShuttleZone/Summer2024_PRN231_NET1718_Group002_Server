using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;

namespace ShuttleZone.DAL.Repositories.ReservationDetail;
[AutoRegister]
public interface IReservationDetailRepository : IGenericRepository<Domain.Entities.ReservationDetail>
{
    
}