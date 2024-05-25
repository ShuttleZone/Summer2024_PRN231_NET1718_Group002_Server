using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.Entities;
using ShuttleZone.DAL.Common.Interfaces;

namespace ShuttleZone.DAL.Repositories;

[AutoRegister]
public interface IClubRepository : IGenericRepository<Club>
{
}
