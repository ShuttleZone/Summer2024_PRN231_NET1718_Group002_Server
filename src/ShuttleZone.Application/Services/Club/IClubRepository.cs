using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Application.Services;

[AutoRegister]
public interface IClubRepository : IGenericRepository<Club>
{
}
