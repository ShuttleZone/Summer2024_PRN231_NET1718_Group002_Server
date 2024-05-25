using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Implementations;
using ShuttleZone.Application.Repositories.IRepositories;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Application.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
